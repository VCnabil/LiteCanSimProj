using LiteCanSimProj._Serialization.DataObjectsDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj._Serialization.Logic
{
    public class DataObject_TextFilterrer
    {
        private Root_VC_PGN_Text_Object _root_VC_PGN_Text_Object_Filtered;
        private List<VC_PGN_Text_Object> vC_PGN_Text_Objects_filteredlist;
        public DataObject_TextFilterrer()
        {
            _root_VC_PGN_Text_Object_Filtered = new Root_VC_PGN_Text_Object();
            vC_PGN_Text_Objects_filteredlist = new List<VC_PGN_Text_Object>();
        }
        public Root_VC_PGN_Text_Object FilterTextObject(Root_VC_PGN_Text_Object argRootTextObj, FilterData argFilterData)
        {
            vC_PGN_Text_Objects_filteredlist = new List<VC_PGN_Text_Object>();
            // Assuming that argRootTextObj contains the list to be filtered
            vC_PGN_Text_Objects_filteredlist = argRootTextObj.VC_PGN_Text_Object;
            var filteredList = GetFilteredby_Boolean(
                argFilterData.Filter_bool_Pgn, argFilterData.Filter_str_Pgn, argFilterData.Filter_Exclude_Pgn,
                argFilterData.Filter_bool_UnitVersions, argFilterData.Filter_str_UnitVersions, argFilterData.Filter_Exclude_version,
                argFilterData.Filter_bool_FromSendingUnit, argFilterData.Filter_str_From, argFilterData.Filter_Exclude_sendingUnit,
                argFilterData.Filter_bool_Configuration, argFilterData.Filter_str_Configuration, argFilterData.Filter_Exclude_configuration,
                argFilterData.Filter_bool_Project, argFilterData.Filter_str_Project, argFilterData.Filter_Exclude_Project,
                argFilterData.Filter_bool_Group, argFilterData.Filter_str_Group, argFilterData.Filter_Exclude_Group,
                argFilterData.Filter_bool_Type, argFilterData.Filter_str_Type, argFilterData.Filter_Exclude_Type,
                argFilterData.Filter_bool_CTRLs, argFilterData.Filter_str_CTRLs, argFilterData.Filter_Exclude_CTRLs
            );
            _root_VC_PGN_Text_Object_Filtered.VC_PGN_Text_Object = filteredList;
            return _root_VC_PGN_Text_Object_Filtered;
        }
        List<VC_PGN_Text_Object> GetFilteredby_Boolean(
             bool arg_byPGN, string argPGNcontains, bool arg_ExcludePGN,
             bool arg_Uversion, string arg_UnitversionContains, bool arg_ExcludeVersion,
             bool arg_byFrom, string argFROMcontains, bool arg_ExcludeFrom,
             bool arg_byConfiguration, string argCONFIGcontains, bool arg_ExcludeConfiguration,
             bool arg_byProject, string argPROJECTcontains, bool arg_ExcludeProject,
             bool arg_byGroup, string argGROUPcontains, bool arg_ExcludeGroup,
             bool arg_byType, string argTYPEcontains, bool arg_ExcludeType,
             bool arg_byCTRLs, string argCTRLscontains, bool arg_ExcludeCTRLs)
        {
            IEnumerable<VC_PGN_Text_Object> filteredList = vC_PGN_Text_Objects_filteredlist;
            if (arg_byPGN)
            {
                if (arg_ExcludePGN)
                {
                    filteredList = filteredList.Where(item => !item.vC_PGNData.PGN.Contains(argPGNcontains));
                }
                else
                {
                    filteredList = filteredList.Where(item => item.vC_PGNData.PGN.Contains(argPGNcontains));
                }
            }
            if (arg_Uversion)
            {
                if (arg_ExcludeVersion)
                {
                    filteredList = filteredList.Where(item => !item.vC_PGN.Sending_Unit_Software_version.Contains(arg_UnitversionContains));
                }
                else
                {
                    filteredList = filteredList.Where(item => item.vC_PGN.Sending_Unit_Software_version.Contains(arg_UnitversionContains));
                }
            }
            if (arg_byFrom)
            {
                if (arg_ExcludeFrom)
                {
                    filteredList = filteredList.Where(item => !item.vC_PGN.From.Contains(argFROMcontains));
                }
                else
                {
                    filteredList = filteredList.Where(item => item.vC_PGN.From.Contains(argFROMcontains));
                }
            }
            if (arg_byConfiguration)
            {
                if (arg_ExcludeConfiguration)
                {
                    filteredList = filteredList.Where(item => !item.vC_PGN.Configuration.Contains(argCONFIGcontains));
                }
                else
                {
                    filteredList = filteredList.Where(item => item.vC_PGN.Configuration.Contains(argCONFIGcontains));
                }
            }
            if (arg_byProject)
            {
                if (arg_ExcludeProject)
                {
                    filteredList = filteredList.Where(item => !item.vC_PGN.Project.Contains(argPROJECTcontains));
                }
                else
                {
                    filteredList = filteredList.Where(item => item.vC_PGN.Project.Contains(argPROJECTcontains));
                }
            }
            if (arg_byGroup)
            {
                if (arg_ExcludeGroup)
                {
                    filteredList = filteredList.Where(item => !item.vC_PGN.Group.Contains(argGROUPcontains));
                }
                else
                {
                    filteredList = filteredList.Where(item => item.vC_PGN.Group.Contains(argGROUPcontains));
                }
            }
            if (arg_byType)
            {
                if (arg_ExcludeType)
                {
                    filteredList = filteredList.Where(item => !item.vC_PGN.Type.Contains(argTYPEcontains));
                }
                else
                {
                    filteredList = filteredList.Where(item => item.vC_PGN.Type.Contains(argTYPEcontains));
                }
            }
            if (arg_byCTRLs)
            {
                if (arg_ExcludeCTRLs)
                {
                    filteredList = filteredList.Where(item => !item.vC_PGN.CTRLs.Contains(argCTRLscontains));
                }
                else
                {
                    filteredList = filteredList.Where(item => item.vC_PGN.CTRLs.Contains(argCTRLscontains));
                }
            }
            return filteredList.ToList();
        }
    }
}
