using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Application.Constants
{
    public static class ListControls
    {
        public static List<object> Defaults
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "View", buttonOption = new { iconCss = "fas fa-eye", cssClass = "e-flat", type = "gridView" } });
                commands.Add(new { title = "Edit", buttonOption = new { iconCss = "fas fa-pen", cssClass = "e-flat", type = "gridEdit" } });
                commands.Add(new { title = "Delete", buttonOption = new { iconCss = "fas fa-trash", cssClass = "e-flat", type = "gridDelete" } });
                return commands;
            }
        }

        public static List<object> NoDelete
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "Edit", buttonOption = new { iconCss = "fas fa-pen", cssClass = "e-flat", type = "gridEdit" } });
                commands.Add(new { title = "View", buttonOption = new { iconCss = "fas fa-eye", cssClass = "e-flat", type = "gridView" } });
                return commands;
            }
        }


        public static List<object> Simplified
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "Edit", buttonOption = new { iconCss = "fas fa-pen", cssClass = "e-flat", type = "gridEdit", } });
                commands.Add(new { title = "Delete", buttonOption = new { iconCss = "fas fa-trash", cssClass = "e-flat", type = "gridDelete" } });
                return commands;
            }
        }

        public static List<object> RolePermission
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "Permissions", buttonOption = new { iconCss = "fas fa-lock", cssClass = "e-flat", type = "gridRole" } });
                commands.Add(new { title = "Edit", buttonOption = new { iconCss = "fas fa-pen", cssClass = "e-flat", type = "gridEdit", } });
                commands.Add(new { title = "Delete", buttonOption = new { iconCss = "fas fa-trash", cssClass = "e-flat", type = "gridDelete" } });
                return commands;
            }
        }


        public static List<object> NoEdit
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "View", buttonOption = new { iconCss = "fas fa-eye", cssClass = "e-flat", type = "gridView" } });
                commands.Add(new { title = "Delete", buttonOption = new { iconCss = "fas fa-trash", cssClass = "e-flat", type = "gridDelete" } });
                return commands;
            }
        }

        public static List<object> EditOnly
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "Edit", buttonOption = new { iconCss = "fas fa-pen", cssClass = "e-flat", type = "gridEdit" } });
                return commands;
            }
        }

        public static List<object> DeleteOnly
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "Delete", buttonOption = new { iconCss = "fas fa-trash", cssClass = "e-flat", type = "gridDelete" } });
                return commands;
            }
        }

        public static List<object> ViewOnly
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "View", buttonOption = new { iconCss = "fas fa-eye", cssClass = "e-flat", type = "gridView" } });
                return commands;
            }
        }
        public static List<object> Custom
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "Link", buttonOption = new { iconCss = "fas fa-bookmark", cssClass = "e-flat", type = "gridView" } });
                return commands;
            }
        }
        public static List<object> DashboardTaskOnly
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "Undo", buttonOption = new { iconCss = "fas fa-arrow-right", cssClass = "e-flat", type = "gridUndo" } });
                commands.Add(new { title = "Delete", buttonOption = new { iconCss = "fas fa-trash", cssClass = "e-flat", type = "gridDelete" } });
                return commands;
            }
        }

        public static List<string> ToolBars
        {
            get
            {
                var toolBar = new List<string>() { "Search" };
                return toolBar;
            }
        }

        public static List<object> ForwardOnly
        {
            get
            {
                List<object> commands = new List<object>();
                commands.Add(new { title = "Forward", buttonOption = new { iconCss = "fas fa-forward", cssClass = "e-flat", type = "gridForward" } });
                return commands;
            }
        }
    }
}
