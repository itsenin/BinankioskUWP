﻿#pragma checksum "C:\Users\Jun\Documents\GitHub\BinankioskUWP\BinanKiosk\v_Job_List.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C525BE37091446FE7DB44A553EA51FA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BinanKiosk
{
    partial class v_Job_List : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.img_trans = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 2:
                {
                    this.tb_Result = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.listViewControl = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 94 "..\..\..\v_Job_List.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.listViewControl).SelectionChanged += this.listViewControl_SelectionChanged;
                    #line default
                }
                break;
            case 4:
                {
                    this.Homebtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 69 "..\..\..\v_Job_List.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Homebtn).Click += this.Homebtn_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.Searchbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 71 "..\..\..\v_Job_List.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Searchbtn).Click += this.Searchbtn_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.Mapbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 73 "..\..\..\v_Job_List.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Mapbtn).Click += this.Mapbtn_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.Servicesbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 75 "..\..\..\v_Job_List.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Servicesbtn).Click += this.Servicesbtn_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.Jobsbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 77 "..\..\..\v_Job_List.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Jobsbtn).Click += this.Jobsbtn_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.Time = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.MainTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

