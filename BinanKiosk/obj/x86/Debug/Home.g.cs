﻿#pragma checksum "C:\Users\doratheexplorer\Desktop\BinankioskUWP\BinanKiosk\Home.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DC66BE0C9F75ABFA82DBA54CFB84C3FD"
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
    partial class Home : 
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
                    #line 9 "..\..\..\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.ROTtest = (global::Microsoft.Toolkit.Uwp.UI.Controls.RotatorTile)(target);
                }
                break;
            case 3:
                {
                    this.Left = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 142 "..\..\..\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Left).Click += this.Left_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.Right = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 147 "..\..\..\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Right).Click += this.Right_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.Homebtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 112 "..\..\..\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Homebtn).Click += this.Homebtn_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.Searchbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 114 "..\..\..\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Searchbtn).Click += this.Searchbtn_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.Mapbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 116 "..\..\..\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Mapbtn).Click += this.Mapbtn_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.Servicesbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 118 "..\..\..\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Servicesbtn).Click += this.Servicesbtn_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.Jobsbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 120 "..\..\..\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Jobsbtn).Click += this.Jobsbtn_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.Time = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.Narrow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 12:
                {
                    this.Normal = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 13:
                {
                    this.Wide = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 14:
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

