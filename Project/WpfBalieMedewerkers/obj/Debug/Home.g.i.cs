// Updated by XamlIntelliSenseFileGenerator 10/05/2021 21:28:43
#pragma checksum "..\..\Home.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0249058D19FDC9F63E3594F67A815D0B53CAA8D5D455C89E245FB9A93146BF87"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfBalieMedewerkers;


namespace WpfBalieMedewerkers
{


    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfBalieMedewerkers;component/home.xaml", System.UriKind.Relative);

#line 1 "..\..\Home.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.btnHome = ((System.Windows.Controls.Button)(target));

#line 23 "..\..\Home.xaml"
                    this.btnHome.Click += new System.Windows.RoutedEventHandler(this.btnHome_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.btnMedewerkers = ((System.Windows.Controls.Button)(target));

#line 24 "..\..\Home.xaml"
                    this.btnMedewerkers.Click += new System.Windows.RoutedEventHandler(this.btnClickMedewerker);

#line default
#line hidden
                    return;
                case 3:
                    this.btnLeden = ((System.Windows.Controls.Button)(target));

#line 25 "..\..\Home.xaml"
                    this.btnLeden.Click += new System.Windows.RoutedEventHandler(this.btnClickLid);

#line default
#line hidden
                    return;
                case 4:
                    this.btnItems = ((System.Windows.Controls.Button)(target));

#line 26 "..\..\Home.xaml"
                    this.btnItems.Click += new System.Windows.RoutedEventHandler(this.btnClickItems);

#line default
#line hidden
                    return;
                case 5:
                    this.Main = ((System.Windows.Controls.Frame)(target));
                    return;
                case 6:
                    this.imgHome = ((System.Windows.Controls.Image)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
