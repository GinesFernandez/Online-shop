﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace UniversalApp
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlTypeInfoProvider _provider;

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo
{
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[21];
            _typeNameTable[0] = "UniversalApp.ViewModels.Base.ViewModelLocator";
            _typeNameTable[1] = "Object";
            _typeNameTable[2] = "UniversalApp.ViewModels.MainPageViewModel";
            _typeNameTable[3] = "UniversalApp.ViewModels.Base.ViewModelBase";
            _typeNameTable[4] = "UniversalApp.ViewModels.Base.ModelBase";
            _typeNameTable[5] = "UniversalApp.ViewModels.LoginViewModel";
            _typeNameTable[6] = "UniversalApp.Globals";
            _typeNameTable[7] = "UniversalApp.Converters.BoolToVisibilityConverter";
            _typeNameTable[8] = "UniversalApp.Converters.InverseBoolToVisibilityConverter";
            _typeNameTable[9] = "Windows.UI.Color";
            _typeNameTable[10] = "System.ValueType";
            _typeNameTable[11] = "Byte";
            _typeNameTable[12] = "UniversalApp.Views.Base.PageBase";
            _typeNameTable[13] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[14] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[15] = "UniversalApp.Views.LoginView";
            _typeNameTable[16] = "Microsoft.Xaml.Interactivity.Interaction";
            _typeNameTable[17] = "Microsoft.Xaml.Interactivity.BehaviorCollection";
            _typeNameTable[18] = "Windows.UI.Xaml.DependencyObjectCollection";
            _typeNameTable[19] = "Windows.UI.Xaml.DependencyObject";
            _typeNameTable[20] = "UniversalApp.Views.MainPage";

            _typeTable = new global::System.Type[21];
            _typeTable[0] = typeof(global::UniversalApp.ViewModels.Base.ViewModelLocator);
            _typeTable[1] = typeof(global::System.Object);
            _typeTable[2] = typeof(global::UniversalApp.ViewModels.MainPageViewModel);
            _typeTable[3] = typeof(global::UniversalApp.ViewModels.Base.ViewModelBase);
            _typeTable[4] = typeof(global::UniversalApp.ViewModels.Base.ModelBase);
            _typeTable[5] = typeof(global::UniversalApp.ViewModels.LoginViewModel);
            _typeTable[6] = typeof(global::UniversalApp.Globals);
            _typeTable[7] = typeof(global::UniversalApp.Converters.BoolToVisibilityConverter);
            _typeTable[8] = typeof(global::UniversalApp.Converters.InverseBoolToVisibilityConverter);
            _typeTable[9] = typeof(global::Windows.UI.Color);
            _typeTable[10] = typeof(global::System.ValueType);
            _typeTable[11] = typeof(global::System.Byte);
            _typeTable[12] = typeof(global::UniversalApp.Views.Base.PageBase);
            _typeTable[13] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[14] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[15] = typeof(global::UniversalApp.Views.LoginView);
            _typeTable[16] = typeof(global::Microsoft.Xaml.Interactivity.Interaction);
            _typeTable[17] = typeof(global::Microsoft.Xaml.Interactivity.BehaviorCollection);
            _typeTable[18] = typeof(global::Windows.UI.Xaml.DependencyObjectCollection);
            _typeTable[19] = typeof(global::Windows.UI.Xaml.DependencyObject);
            _typeTable[20] = typeof(global::UniversalApp.Views.MainPage);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_ViewModelLocator() { return new global::UniversalApp.ViewModels.Base.ViewModelLocator(); }
        private object Activate_4_ModelBase() { return new global::UniversalApp.ViewModels.Base.ModelBase(); }
        private object Activate_6_Globals() { return new global::UniversalApp.Globals(); }
        private object Activate_7_BoolToVisibilityConverter() { return new global::UniversalApp.Converters.BoolToVisibilityConverter(); }
        private object Activate_8_InverseBoolToVisibilityConverter() { return new global::UniversalApp.Converters.InverseBoolToVisibilityConverter(); }
        private object Activate_12_PageBase() { return new global::UniversalApp.Views.Base.PageBase(); }
        private object Activate_15_LoginView() { return new global::UniversalApp.Views.LoginView(); }
        private object Activate_17_BehaviorCollection() { return new global::Microsoft.Xaml.Interactivity.BehaviorCollection(); }
        private object Activate_20_MainPage() { return new global::UniversalApp.Views.MainPage(); }
        private void VectorAdd_17_BehaviorCollection(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::Windows.UI.Xaml.DependencyObject>)instance;
            var newItem = (global::Windows.UI.Xaml.DependencyObject)item;
            collection.Add(newItem);
        }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  UniversalApp.ViewModels.Base.ViewModelLocator
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_0_ViewModelLocator;
                userType.AddMemberName("MainPageViewModel");
                userType.AddMemberName("LoginViewModel");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Object
                xamlType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  UniversalApp.ViewModels.MainPageViewModel
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("UniversalApp.ViewModels.Base.ViewModelBase"));
                userType.SetIsReturnTypeStub();
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 3:   //  UniversalApp.ViewModels.Base.ViewModelBase
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("UniversalApp.ViewModels.Base.ModelBase"));
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 4:   //  UniversalApp.ViewModels.Base.ModelBase
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_4_ModelBase;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 5:   //  UniversalApp.ViewModels.LoginViewModel
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("UniversalApp.ViewModels.Base.ViewModelBase"));
                userType.SetIsReturnTypeStub();
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 6:   //  UniversalApp.Globals
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_6_Globals;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 7:   //  UniversalApp.Converters.BoolToVisibilityConverter
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_7_BoolToVisibilityConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  UniversalApp.Converters.InverseBoolToVisibilityConverter
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_8_InverseBoolToVisibilityConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 9:   //  Windows.UI.Color
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
                userType.AddMemberName("A");
                userType.AddMemberName("B");
                userType.AddMemberName("G");
                userType.AddMemberName("R");
                xamlType = userType;
                break;

            case 10:   //  System.ValueType
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                xamlType = userType;
                break;

            case 11:   //  Byte
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 12:   //  UniversalApp.Views.Base.PageBase
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_12_PageBase;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 13:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 14:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 15:   //  UniversalApp.Views.LoginView
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("UniversalApp.Views.Base.PageBase"));
                userType.Activator = Activate_15_LoginView;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 16:   //  Microsoft.Xaml.Interactivity.Interaction
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.AddMemberName("Behaviors");
                xamlType = userType;
                break;

            case 17:   //  Microsoft.Xaml.Interactivity.BehaviorCollection
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.DependencyObjectCollection"));
                userType.CollectionAdd = VectorAdd_17_BehaviorCollection;
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 18:   //  Windows.UI.Xaml.DependencyObjectCollection
                xamlType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 19:   //  Windows.UI.Xaml.DependencyObject
                xamlType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 20:   //  UniversalApp.Views.MainPage
                userType = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("UniversalApp.Views.Base.PageBase"));
                userType.Activator = Activate_20_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_ViewModelLocator_MainPageViewModel(object instance)
        {
            var that = (global::UniversalApp.ViewModels.Base.ViewModelLocator)instance;
            return that.MainPageViewModel;
        }
        private object get_1_ViewModelLocator_LoginViewModel(object instance)
        {
            var that = (global::UniversalApp.ViewModels.Base.ViewModelLocator)instance;
            return that.LoginViewModel;
        }
        private object get_2_Color_A(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.A;
        }
        private void set_2_Color_A(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.A = (global::System.Byte)Value;
        }
        private object get_3_Color_B(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.B;
        }
        private void set_3_Color_B(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.B = (global::System.Byte)Value;
        }
        private object get_4_Color_G(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.G;
        }
        private void set_4_Color_G(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.G = (global::System.Byte)Value;
        }
        private object get_5_Color_R(object instance)
        {
            var that = (global::Windows.UI.Color)instance;
            return that.R;
        }
        private void set_5_Color_R(object instance, object Value)
        {
            var that = (global::Windows.UI.Color)instance;
            that.R = (global::System.Byte)Value;
        }
        private object get_6_Interaction_Behaviors(object instance)
        {
            return global::Microsoft.Xaml.Interactivity.Interaction.GetBehaviors((global::Windows.UI.Xaml.DependencyObject)instance);
        }
        private void set_6_Interaction_Behaviors(object instance, object Value)
        {
            global::Microsoft.Xaml.Interactivity.Interaction.SetBehaviors((global::Windows.UI.Xaml.DependencyObject)instance, (global::Microsoft.Xaml.Interactivity.BehaviorCollection)Value);
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlMember xamlMember = null;
            global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "UniversalApp.ViewModels.Base.ViewModelLocator.MainPageViewModel":
                userType = (global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("UniversalApp.ViewModels.Base.ViewModelLocator");
                xamlMember = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlMember(this, "MainPageViewModel", "UniversalApp.ViewModels.MainPageViewModel");
                xamlMember.Getter = get_0_ViewModelLocator_MainPageViewModel;
                xamlMember.SetIsReadOnly();
                break;
            case "UniversalApp.ViewModels.Base.ViewModelLocator.LoginViewModel":
                userType = (global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("UniversalApp.ViewModels.Base.ViewModelLocator");
                xamlMember = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlMember(this, "LoginViewModel", "UniversalApp.ViewModels.LoginViewModel");
                xamlMember.Getter = get_1_ViewModelLocator_LoginViewModel;
                xamlMember.SetIsReadOnly();
                break;
            case "Windows.UI.Color.A":
                userType = (global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlMember(this, "A", "Byte");
                xamlMember.Getter = get_2_Color_A;
                xamlMember.Setter = set_2_Color_A;
                break;
            case "Windows.UI.Color.B":
                userType = (global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlMember(this, "B", "Byte");
                xamlMember.Getter = get_3_Color_B;
                xamlMember.Setter = set_3_Color_B;
                break;
            case "Windows.UI.Color.G":
                userType = (global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlMember(this, "G", "Byte");
                xamlMember.Getter = get_4_Color_G;
                xamlMember.Setter = set_4_Color_G;
                break;
            case "Windows.UI.Color.R":
                userType = (global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Windows.UI.Color");
                xamlMember = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlMember(this, "R", "Byte");
                xamlMember.Getter = get_5_Color_R;
                xamlMember.Setter = set_5_Color_R;
                break;
            case "Microsoft.Xaml.Interactivity.Interaction.Behaviors":
                userType = (global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Microsoft.Xaml.Interactivity.Interaction");
                xamlMember = new global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlMember(this, "Behaviors", "Microsoft.Xaml.Interactivity.BehaviorCollection");
                xamlMember.SetTargetTypeName("Windows.UI.Xaml.DependencyObject");
                xamlMember.SetIsAttachable();
                xamlMember.Getter = get_6_Interaction_Behaviors;
                xamlMember.Setter = set_6_Interaction_Behaviors;
                break;
            }
            return xamlMember;
        }
    }

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlSystemBaseType
    {
        global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::UniversalApp.UniversalApp_WindowsPhone_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}


