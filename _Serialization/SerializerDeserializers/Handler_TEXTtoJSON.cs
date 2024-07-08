using LiteCanSimProj._Serialization.DataObjectsDefinition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LiteCanSimProj._Globalz.G_Properties;
using static LiteCanSimProj._Globalz.G_Paths;

namespace LiteCanSimProj._Serialization.SerializerDeserializers
{
    public class Handler_TEXTtoJSON
    {
        //this is a list of strings for each line of the text at ground zero
        // a block looks like this : 

        //============================================================================
        //CAN Messages From : VMU
        //VC_PGN_ID : 166
        //PGN_32bit : 65300
        //address Port: 00
        //address Stbd: 01
        //priority    : 18
        //Sending_Unit_Software_version : N/A
        //info: found in  MRADS StandardShips
        //Configuration : MRADS test
        //Project : CCM test keep
        //============================================================================
        //    0xFF14    ( My Title )
        //emptyline
        //            - Byte0 : helloLabel Revision
        //emptyline
        //            - Byte1 : helloSlider
        //emptyline
        //            - Byte2 : duobyte LO |B2*101
        //emptyline
        //            - Byte3 : duobyte HI |B2
        //emptyline
        //            - Byte4 : duobyteset (5,20,60) LO
        //emptyline
        //            - Byte5 : duobyteset (5,20,60) HI
        //emptyline
        //            - Byte6 : helloSliderset (10,20,30)
        //emptyline
        //            - Byte7 : N/A

        Root_VC_PGN_Text_Object root_VC_PGN_Text_Object;
        public int NumberOfPgnsInGroundZeroTextFile { get; private set; }
        public Handler_TEXTtoJSON()
        {
            NumberOfPgnsInGroundZeroTextFile = 0;

        }

        public void Serialize_GroundZero_Tex_andWrite_JsonFile(string arg_filePath)
        {
            List<List<string>> ListOfTextPgnBlocks = new List<List<string>>();
            List<string> All_lines_in_GroundZeroTextFile = new List<string>();
            using (var reader = new StreamReader(arg_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace("\t", "    "); // Replace tabs with 4 spaces
                    All_lines_in_GroundZeroTextFile.Add(line);
                }
            }
            if (All_lines_in_GroundZeroTextFile.Count < 1)
            {
                if (!G_SuppressMessageBoxes) MessageBox.Show("No lines in file");
            }

            //*******************************************************************************************************************************start blocks 
            string DelimiterBlock = "============================================================================";
            List<string> _cur_block = new List<string>();
            bool blockStarted = false;
            for (int l = 0; l < All_lines_in_GroundZeroTextFile.Count; l++)
            {
                if (l < All_lines_in_GroundZeroTextFile.Count)
                {
                    if (l < All_lines_in_GroundZeroTextFile.Count - 1)
                    {
                        if (All_lines_in_GroundZeroTextFile[l] == DelimiterBlock && All_lines_in_GroundZeroTextFile[l + 1].StartsWith("CAN Messages"))
                        {
                            blockStarted = true;
                        }
                        if (String.IsNullOrWhiteSpace(All_lines_in_GroundZeroTextFile[l]) && All_lines_in_GroundZeroTextFile[l + 1].StartsWith("==========="))
                        {
                            blockStarted = false;
                        }
                    }
                    if (l == All_lines_in_GroundZeroTextFile.Count - 1)
                    {
                        blockStarted = false;
                    }
                }
                else
                {
                    blockStarted = false;
                }
                if (blockStarted)
                {
                    if (_cur_block == null)
                    {
                        _cur_block = new List<string>();
                    }
                    if (!String.IsNullOrWhiteSpace(All_lines_in_GroundZeroTextFile[l]))
                    {
                        string trimmedString = All_lines_in_GroundZeroTextFile[l].TrimStart();
                        _cur_block.Add(trimmedString);
                    }
                }
                else
                {
                    if (_cur_block != null)
                    {
                        if (!String.IsNullOrWhiteSpace(All_lines_in_GroundZeroTextFile[l]))
                        {
                            string trimmedString = All_lines_in_GroundZeroTextFile[l].TrimStart();
                            _cur_block.Add(trimmedString);
                        }
                        ListOfTextPgnBlocks.Add(_cur_block);
                        _cur_block = new List<string>();
                    }
                }
            }
            if (_cur_block.Count > 0)
            {
                ListOfTextPgnBlocks.Add(_cur_block);
            }

            //*******************************************************************************************************************************End blocks 
            NumberOfPgnsInGroundZeroTextFile = ListOfTextPgnBlocks.Count;

            root_VC_PGN_Text_Object = new Root_VC_PGN_Text_Object();
            root_VC_PGN_Text_Object.ProjectName = "VC_Projectnew";
            root_VC_PGN_Text_Object.VC_PGN_Text_Object = new List<VC_PGN_Text_Object>();

            foreach (var block in ListOfTextPgnBlocks)
            {
                VC_PGN_Text_Object vC_PGN_Text_Object = StringListBlock_to_VC_PGN_Text_Object(block);
                root_VC_PGN_Text_Object.VC_PGN_Text_Object.Add(vC_PGN_Text_Object);
            }

            for (int i = 0; i < root_VC_PGN_Text_Object.VC_PGN_Text_Object.Count; i++)
            {
                root_VC_PGN_Text_Object.VC_PGN_Text_Object[i].vC_PGN.VC_PGN_ID = i;// -------------------------------------------------sets all id to 0
                string hexString = root_VC_PGN_Text_Object.VC_PGN_Text_Object[i].vC_PGNData.PGN;
                uint intValue;

                // Remove the '0x' prefix if present
                if (hexString.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    hexString = hexString.Substring(2);
                }

                // Convert the hexadecimal string to an integer
                intValue = Convert.ToUInt32(hexString, 16);
                root_VC_PGN_Text_Object.VC_PGN_Text_Object[i].vC_PGN.PGN_32bit = intValue;
            }

            NumberOfPgnsInGroundZeroTextFile = root_VC_PGN_Text_Object.VC_PGN_Text_Object.Count();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(root_VC_PGN_Text_Object, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Get_Path_JSONFile(), json);
        }

        private VC_PGN_Text_Object StringListBlock_to_VC_PGN_Text_Object(List<string> argBlock)
        {
            VC_PGN_Text_Object vC_PGN_Text_Object = new VC_PGN_Text_Object();
            VC_PGN vC_PGN = new VC_PGN();
            VC_PGNData vC_PGNData = new VC_PGNData();
            vC_PGN_Text_Object.vC_PGN = vC_PGN;
            vC_PGN_Text_Object.vC_PGNData = vC_PGNData;

            int linNum = 0;
            if (argBlock != null && argBlock.Count > 12)
            {
                //=============================================
                linNum++;
                vC_PGN.From = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                string stringValue_IDVal = argBlock[linNum].Split(':')[1].Trim();
                int idVal = int.TryParse(stringValue_IDVal, out idVal) ? idVal : -1;
                vC_PGN.VC_PGN_ID = idVal;
                linNum++;
                string stringValue_PGN_32bit = argBlock[linNum].Split(':')[1].Trim();
                uint pgn_32bit = uint.TryParse(stringValue_PGN_32bit, out pgn_32bit) ? pgn_32bit : 0;
                vC_PGN.PGN_32bit = pgn_32bit;
                linNum++;
                vC_PGN.adrs_Port = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.adrs_Stbd = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.priority = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.Sending_Unit_Software_version = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.info = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.Configuration = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.Project = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.Type = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.Comments = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.Group = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                vC_PGN.CTRLs = argBlock[linNum].Split(':')[1].Trim();
                linNum++;
                //=============================================
                linNum++;
                vC_PGNData.PGN = argBlock[linNum].Split('(')[0].Trim();
                string pattern = @"\(([^)]*)\)";
                Match match = Regex.Match(argBlock[linNum], pattern);
                vC_PGNData.DescritionPGN = match.Success ? match.Groups[1].Value : ""; ;

                int index = linNum + 1;
                while (index < argBlock.Count)
                {
                    string line = argBlock[index].Trim();

                    if (line.StartsWith("- Byte"))
                    {
                        int byteNumber = int.TryParse(line.Substring(6).Split(':')[0].Trim(), out byteNumber) ? byteNumber : -1;
                        string byteDescription = line.Contains(":") ? line.Split(':')[1].Trim() : "N/A";
                        List<string> bitTitles = new List<string>();
                        index++; // Move to the next line after Byte line
                        // Collect bit titles if available
                        while (index < argBlock.Count && argBlock[index].Trim().StartsWith("- b"))
                        {
                            string bitLine = argBlock[index].Trim();
                            bitTitles.Add(bitLine.Split(':')[1].Trim());
                            index++;
                        }
                        // Assign data to VC_PGNData
                        if (byteNumber != -1) // Check if byte number was successfully parsed
                        {
                            AssignByteData2(vC_PGNData, byteDescription, bitTitles, byteNumber);
                        }
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            else
            {
                MessageBox.Show(argBlock == null ? "Block is null" : "Block is too small");
            }
            return vC_PGN_Text_Object;
        }
        private void AssignByteData2(VC_PGNData vC_PGNData, string argbytedescription, List<string> bitTitles, int argbytenumber)
        {
            switch (argbytenumber)
            {
                case 0:
                    vC_PGNData.DescritionByte0 = argbytedescription;
                    vC_PGNData.Byte0 = bitTitles;
                    break;
                case 1:
                    vC_PGNData.DescritionByte1 = argbytedescription;
                    vC_PGNData.Byte1 = bitTitles;
                    break;
                case 2:
                    vC_PGNData.DescritionByte2 = argbytedescription;
                    vC_PGNData.Byte2 = bitTitles;
                    break;
                case 3:
                    vC_PGNData.DescritionByte3 = argbytedescription;
                    vC_PGNData.Byte3 = bitTitles;
                    break;
                case 4:
                    vC_PGNData.DescritionByte4 = argbytedescription;
                    vC_PGNData.Byte4 = bitTitles;
                    break;
                case 5:
                    vC_PGNData.DescritionByte5 = argbytedescription;
                    vC_PGNData.Byte5 = bitTitles;
                    break;
                case 6:
                    vC_PGNData.DescritionByte6 = argbytedescription;
                    vC_PGNData.Byte6 = bitTitles;
                    break;
                case 7:
                    vC_PGNData.DescritionByte7 = argbytedescription;
                    vC_PGNData.Byte7 = bitTitles;
                    break;
                    // Add additional cases if you have more bytes
            }
        }
        public void WriteJsonFile(string arg_filePath)
        {
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(root_VC_PGN_Text_Object, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText(arg_filePath, json);
        }
    }
}
