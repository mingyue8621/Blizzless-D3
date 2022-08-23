// Generated by ProtoGen, Version=2.4.1.473, Culture=neutral, PublicKeyToken=55f7125234beb589.  DO NOT EDIT!
#pragma warning disable 1591, 0612
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace bgs.protocol.club.v1 {
  
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
  public static partial class ClubType {
  
    #region Extension registration
    public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
    }
    #endregion
    #region Static variables
    internal static pbd::MessageDescriptor internal__static_bgs_protocol_club_v1_UniqueClubType__Descriptor;
    internal static pb::FieldAccess.FieldAccessorTable<global::bgs.protocol.club.v1.UniqueClubType, global::bgs.protocol.club.v1.UniqueClubType.Builder> internal__static_bgs_protocol_club_v1_UniqueClubType__FieldAccessorTable;
    #endregion
    #region Descriptor
    public static pbd::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbd::FileDescriptor descriptor;
    
    static ClubType() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          "CiFiZ3MvbG93L3BiL2NsaWVudC9jbHViX3R5cGUucHJvdG8SFGJncy5wcm90" + 
          "b2NvbC5jbHViLnYxIj4KDlVuaXF1ZUNsdWJUeXBlEhgKB3Byb2dyYW0YASAB" + 
          "KAdSB3Byb2dyYW0SEgoEbmFtZRgCIAEoCVIEbmFtZQ==");
      pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
        descriptor = root;
        internal__static_bgs_protocol_club_v1_UniqueClubType__Descriptor = Descriptor.MessageTypes[0];
        internal__static_bgs_protocol_club_v1_UniqueClubType__FieldAccessorTable = 
            new pb::FieldAccess.FieldAccessorTable<global::bgs.protocol.club.v1.UniqueClubType, global::bgs.protocol.club.v1.UniqueClubType.Builder>(internal__static_bgs_protocol_club_v1_UniqueClubType__Descriptor,
                new string[] { "Program", "Name", });
        pb::ExtensionRegistry registry = pb::ExtensionRegistry.CreateInstance();
        RegisterAllExtensions(registry);
        return registry;
      };
      pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
          new pbd::FileDescriptor[] {
          }, assigner);
    }
    #endregion
    
  }
  #region Messages
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
  public sealed partial class UniqueClubType : pb::GeneratedMessage<UniqueClubType, UniqueClubType.Builder> {
    private UniqueClubType() { }
    private static readonly UniqueClubType defaultInstance = new UniqueClubType().MakeReadOnly();
    private static readonly string[] _uniqueClubTypeFieldNames = new string[] { "name", "program" };
    private static readonly uint[] _uniqueClubTypeFieldTags = new uint[] { 18, 13 };
    public static UniqueClubType DefaultInstance {
      get { return defaultInstance; }
    }
    
    public override UniqueClubType DefaultInstanceForType {
      get { return DefaultInstance; }
    }
    
    protected override UniqueClubType ThisMessage {
      get { return this; }
    }
    
    public static pbd::MessageDescriptor Descriptor {
      get { return global::bgs.protocol.club.v1.ClubType.internal__static_bgs_protocol_club_v1_UniqueClubType__Descriptor; }
    }
    
    protected override pb::FieldAccess.FieldAccessorTable<UniqueClubType, UniqueClubType.Builder> InternalFieldAccessors {
      get { return global::bgs.protocol.club.v1.ClubType.internal__static_bgs_protocol_club_v1_UniqueClubType__FieldAccessorTable; }
    }
    
    public const int ProgramFieldNumber = 1;
    private bool hasProgram;
    private uint program_;
    public bool HasProgram {
      get { return hasProgram; }
    }
    public uint Program {
      get { return program_; }
    }
    
    public const int NameFieldNumber = 2;
    private bool hasName;
    private string name_ = "";
    public bool HasName {
      get { return hasName; }
    }
    public string Name {
      get { return name_; }
    }
    
    public override bool IsInitialized {
      get {
        return true;
      }
    }
    
    public override void WriteTo(pb::ICodedOutputStream output) {
      int size = SerializedSize;
      string[] field_names = _uniqueClubTypeFieldNames;
      if (hasProgram) {
        output.WriteFixed32(1, field_names[1], Program);
      }
      if (hasName) {
        output.WriteString(2, field_names[0], Name);
      }
      UnknownFields.WriteTo(output);
    }
    
    private int memoizedSerializedSize = -1;
    public override int SerializedSize {
      get {
        int size = memoizedSerializedSize;
        if (size != -1) return size;
        
        size = 0;
        if (hasProgram) {
          size += pb::CodedOutputStream.ComputeFixed32Size(1, Program);
        }
        if (hasName) {
          size += pb::CodedOutputStream.ComputeStringSize(2, Name);
        }
        size += UnknownFields.SerializedSize;
        memoizedSerializedSize = size;
        return size;
      }
    }
    
    public static UniqueClubType ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static UniqueClubType ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static UniqueClubType ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static UniqueClubType ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static UniqueClubType ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static UniqueClubType ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static UniqueClubType ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static UniqueClubType ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static UniqueClubType ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static UniqueClubType ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private UniqueClubType MakeReadOnly() {
      return this;
    }
    
    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(UniqueClubType prototype) {
      return new Builder(prototype);
    }
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
    public sealed partial class Builder : pb::GeneratedBuilder<UniqueClubType, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(UniqueClubType cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }
      
      private bool resultIsReadOnly;
      private UniqueClubType result;
      
      private UniqueClubType PrepareBuilder() {
        if (resultIsReadOnly) {
          UniqueClubType original = result;
          result = new UniqueClubType();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }
      
      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }
      
      protected override UniqueClubType MessageBeingBuilt {
        get { return PrepareBuilder(); }
      }
      
      public override Builder Clear() {
        result = DefaultInstance;
        resultIsReadOnly = true;
        return this;
      }
      
      public override Builder Clone() {
        if (resultIsReadOnly) {
          return new Builder(result);
        } else {
          return new Builder().MergeFrom(result);
        }
      }
      
      public override pbd::MessageDescriptor DescriptorForType {
        get { return global::bgs.protocol.club.v1.UniqueClubType.Descriptor; }
      }
      
      public override UniqueClubType DefaultInstanceForType {
        get { return global::bgs.protocol.club.v1.UniqueClubType.DefaultInstance; }
      }
      
      public override UniqueClubType BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }
      
      public override Builder MergeFrom(pb::IMessage other) {
        if (other is UniqueClubType) {
          return MergeFrom((UniqueClubType) other);
        } else {
          base.MergeFrom(other);
          return this;
        }
      }
      
      public override Builder MergeFrom(UniqueClubType other) {
        if (other == global::bgs.protocol.club.v1.UniqueClubType.DefaultInstance) return this;
        PrepareBuilder();
        if (other.HasProgram) {
          Program = other.Program;
        }
        if (other.HasName) {
          Name = other.Name;
        }
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input) {
        return MergeFrom(input, pb::ExtensionRegistry.Empty);
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
        PrepareBuilder();
        pb::UnknownFieldSet.Builder unknownFields = null;
        uint tag;
        string field_name;
        while (input.ReadTag(out tag, out field_name)) {
          if(tag == 0 && field_name != null) {
            int field_ordinal = global::System.Array.BinarySearch(_uniqueClubTypeFieldNames, field_name, global::System.StringComparer.Ordinal);
            if(field_ordinal >= 0)
              tag = _uniqueClubTypeFieldTags[field_ordinal];
            else {
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              continue;
            }
          }
          switch (tag) {
            case 0: {
              throw pb::InvalidProtocolBufferException.InvalidTag();
            }
            default: {
              if (pb::WireFormat.IsEndGroupTag(tag)) {
                if (unknownFields != null) {
                  this.UnknownFields = unknownFields.Build();
                }
                return this;
              }
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              break;
            }
            case 13: {
              result.hasProgram = input.ReadFixed32(ref result.program_);
              break;
            }
            case 18: {
              result.hasName = input.ReadString(ref result.name_);
              break;
            }
          }
        }
        
        if (unknownFields != null) {
          this.UnknownFields = unknownFields.Build();
        }
        return this;
      }
      
      
      public bool HasProgram {
        get { return result.hasProgram; }
      }
      public uint Program {
        get { return result.Program; }
        set { SetProgram(value); }
      }
      public Builder SetProgram(uint value) {
        PrepareBuilder();
        result.hasProgram = true;
        result.program_ = value;
        return this;
      }
      public Builder ClearProgram() {
        PrepareBuilder();
        result.hasProgram = false;
        result.program_ = 0;
        return this;
      }
      
      public bool HasName {
        get { return result.hasName; }
      }
      public string Name {
        get { return result.Name; }
        set { SetName(value); }
      }
      public Builder SetName(string value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasName = true;
        result.name_ = value;
        return this;
      }
      public Builder ClearName() {
        PrepareBuilder();
        result.hasName = false;
        result.name_ = "";
        return this;
      }
    }
    static UniqueClubType() {
      object.ReferenceEquals(global::bgs.protocol.club.v1.ClubType.Descriptor, null);
    }
  }
  
  #endregion
  
}

#endregion Designer generated code
