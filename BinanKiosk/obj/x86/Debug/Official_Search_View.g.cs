﻿#pragma checksum "C:\Users\Jun\Documents\GitHub\BinankioskUWP\BinanKiosk\Official_Search_View.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "25B8E092FA4D022578321148E00AB2FA"
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
    partial class Official_Search_View : 
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
                    #line 8 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.MyGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 10 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.MyGrid).Tapped += this.MyGrid_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    this.MyImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 4:
                {
                    this.ScrollViewer_Dimension = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5:
                {
                    this.Row_Border = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 6:
                {
                    this.Official_Name = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.ScrollView_Border = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 8:
                {
                    this.Official_Image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 9:
                {
                    this.btn_Find = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 142 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_Find).Tapped += this.btn_Find_Tapped;
                    #line default
                }
                break;
            case 10:
                {
                    this.lb_Position = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.lb_Office = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.lb_Department = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.lb_Department_Description = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14:
                {
                    this.Searchbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 70 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Searchbtn).Tapped += this.Searchbtn_Tapped;
                    #line default
                }
                break;
            case 15:
                {
                    this.Mapbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 72 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Mapbtn).Tapped += this.Mapbtn_Tapped;
                    #line default
                }
                break;
            case 16:
                {
                    this.Servicesbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 74 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Servicesbtn).Tapped += this.Servicesbtn_Tapped;
                    #line default
                }
                break;
            case 17:
                {
                    this.Jobsbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 76 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Jobsbtn).Tapped += this.Jobsbtn_Tapped;
                    #line default
                }
                break;
            case 18:
                {
                    this.Eventbtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 78 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Eventbtn).Tapped += this.Eventbtn_Tapped;
                    #line default
                }
                break;
            case 19:
                {
                    this.Time = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20:
                {
                    this.btn_Back = (global::Windows.UI.Xaml.Controls.SymbolIcon)(target);
                    #line 35 "..\..\..\Official_Search_View.xaml"
                    ((global::Windows.UI.Xaml.Controls.SymbolIcon)this.btn_Back).Tapped += this.btn_Back_Tapped;
                    #line default
                }
                break;
            case 21:
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

