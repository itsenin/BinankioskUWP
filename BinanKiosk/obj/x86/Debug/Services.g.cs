﻿#pragma checksum "C:\Users\Jun\Documents\GitHub\BinankioskUWP\BinanKiosk\Services.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6BD6418FDC12AF0D1B5F4B9CD3496D71"
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
    partial class Services : 
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
                    #line 9 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 38 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Tapped += this.bt_CitizenCharter_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 39 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Tapped += this.bt_Locate_Tapped;
                    #line default
                }
                break;
            case 4:
                {
                    this.MyGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 46 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.MyGrid).Tapped += this.MyGrid_Tapped;
                    #line default
                }
                break;
            case 5:
                {
                    this.MyImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 6:
                {
                    this.Left = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 134 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Left).Tapped += this.Left_Tapped;
                    #line default
                }
                break;
            case 7:
                {
                    this.Right = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 139 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Right).Tapped += this.Right_Tapped;
                    #line default
                }
                break;
            case 8:
                {
                    this.AdaptiveGridViewControl = (global::Microsoft.Toolkit.Uwp.UI.Controls.AdaptiveGridView)(target);
                    #line 190 "..\..\..\Services.xaml"
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.AdaptiveGridView)this.AdaptiveGridViewControl).Tapped += this.AdaptiveGridViewControl_Tapped;
                    #line default
                }
                break;
            case 9:
                {
                    this.tb_PageNum = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.Searchbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 105 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Searchbtn).Tapped += this.Searchbtn_Tapped;
                    #line default
                }
                break;
            case 11:
                {
                    this.Mapbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 107 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Mapbtn).Tapped += this.Mapbtn_Tapped;
                    #line default
                }
                break;
            case 12:
                {
                    this.Servicesbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 109 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Servicesbtn).Tapped += this.Servicesbtn_Tapped;
                    #line default
                }
                break;
            case 13:
                {
                    this.Jobsbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 111 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Jobsbtn).Tapped += this.Jobsbtn_Tapped;
                    #line default
                }
                break;
            case 14:
                {
                    this.Eventbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 113 "..\..\..\Services.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Eventbtn).Tapped += this.Eventbtn_Tapped;
                    #line default
                }
                break;
            case 15:
                {
                    this.Time = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16:
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

