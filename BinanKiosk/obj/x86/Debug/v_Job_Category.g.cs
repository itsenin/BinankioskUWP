﻿#pragma checksum "C:\Users\doratheexplorer\Desktop\BinankioskUWP\BinanKiosk\v_Job_Category.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "67BABA5BD45FFDE5F4040AB9D6043BF6"
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
    partial class v_Job_Category : 
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
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 9 "..\..\..\v_Job_Category.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.AdaptiveGridViewControl = (global::Microsoft.Toolkit.Uwp.UI.Controls.AdaptiveGridView)(target);
                    #line 127 "..\..\..\v_Job_Category.xaml"
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.AdaptiveGridView)this.AdaptiveGridViewControl).ItemClick += this.AdaptiveGridViewControl_ItemClick;
                    #line default
                }
                break;
            case 3:
                {
                    this.Homebtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 88 "..\..\..\v_Job_Category.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Homebtn).Click += this.Homebtn_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.Searchbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 90 "..\..\..\v_Job_Category.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Searchbtn).Click += this.Searchbtn_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.Mapbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 92 "..\..\..\v_Job_Category.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Mapbtn).Click += this.Mapbtn_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.Servicesbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 94 "..\..\..\v_Job_Category.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Servicesbtn).Click += this.Servicesbtn_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.Jobsbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 96 "..\..\..\v_Job_Category.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Jobsbtn).Click += this.Jobsbtn_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.Time = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
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

