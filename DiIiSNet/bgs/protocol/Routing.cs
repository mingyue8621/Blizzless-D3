// Generated by ProtoGen, Version=2.4.1.473, Culture=neutral, PublicKeyToken=55f7125234beb589.  DO NOT EDIT!
#pragma warning disable 1591, 0612
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace bgs.protocol {
  
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
  public static partial class Routing {
  
    #region Extension registration
    public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
    }
    #endregion
    #region Static variables
    #endregion
    #region Descriptor
    public static pbd::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbd::FileDescriptor descriptor;
    
    static Routing() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          "CjFiZ3MvbG93L3BiL2NsaWVudC9nbG9iYWxfZXh0ZW5zaW9ucy9yb3V0aW5n" + 
          "LnByb3RvEgxiZ3MucHJvdG9jb2wqxAEKGUNsaWVudElkZW50aXR5Um91dGlu" + 
          "Z1R5cGUSJAogQ0xJRU5UX0lERU5USVRZX1JPVVRJTkdfRElTQUJMRUQQABIu" + 
          "CipDTElFTlRfSURFTlRJVFlfUk9VVElOR19CQVRUTEVfTkVUX0FDQ09VTlQQ" + 
          "ARIoCiRDTElFTlRfSURFTlRJVFlfUk9VVElOR19HQU1FX0FDQ09VTlQQAhIn" + 
          "CiNDTElFTlRfSURFTlRJVFlfUk9VVElOR19JTlNUQU5DRV9JRBAD");
      pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
        descriptor = root;
        return null;
      };
      pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
          new pbd::FileDescriptor[] {
          }, assigner);
    }
    #endregion
    
  }
  #region Enums
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
  public enum ClientIdentityRoutingType {
    CLIENT_IDENTITY_ROUTING_DISABLED = 0,
    CLIENT_IDENTITY_ROUTING_BATTLE_NET_ACCOUNT = 1,
    CLIENT_IDENTITY_ROUTING_GAME_ACCOUNT = 2,
    CLIENT_IDENTITY_ROUTING_INSTANCE_ID = 3,
  }
  
  #endregion
  
}

#endregion Designer generated code
