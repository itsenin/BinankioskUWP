﻿#pragma checksum "C:\Users\Jun\Documents\GitHub\BinankioskUWP\BinanKiosk\Search.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "648A3AFFE0BD17C9B3A37E4C0D77CBFF"
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
    partial class Search : 
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
                    #line 10 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.tb_Search = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    #line 172 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.tb_Search).TextChanged += this.tb_Search_TextChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.Left = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 176 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Left).Click += this.Left_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.Right = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 181 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Right).Click += this.Right_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.AdaptiveGridViewControl = (global::Microsoft.Toolkit.Uwp.UI.Controls.AdaptiveGridView)(target);
                    #line 194 "..\..\..\Search.xaml"
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.AdaptiveGridView)this.AdaptiveGridViewControl).ItemClick += this.AdaptiveGridViewControl_ItemClick;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element6 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 165 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element6).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 7:
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element7 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 158 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element7).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element8 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 151 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element8).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element9 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 144 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element9).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 10:
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element10 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 137 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element10).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 11:
                {
                    this.Homebtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 95 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Homebtn).Click += this.Homebtn_Click;
                    #line default
                }
                break;
            case 12:
                {
                    this.Searchbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 97 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Searchbtn).Click += this.Searchbtn_Click;
                    #line default
                }
                break;
            case 13:
                {
                    this.Mapbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 99 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Mapbtn).Click += this.Mapbtn_Click;
                    #line default
                }
                break;
            case 14:
                {
                    this.Servicesbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 101 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Servicesbtn).Click += this.Servicesbtn_Click;
                    #line default
                }
                break;
            case 15:
                {
                    this.Jobsbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 103 "..\..\..\Search.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Jobsbtn).Click += this.Jobsbtn_Click;
                    #line default
                }
                break;
            case 16:
                {
                    this.Time = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17:
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

