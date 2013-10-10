// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.38967
//    <NameSpace>XmlResourceAcess</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>False</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace XmlResourceAcess
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;


    public partial class Player
    {

        private string nameField;

        private PlayerMatchStatistics matchStatisticsField;

        private List<PlayerPlayer> associatedPlayersField;

        private string idField;

        public Player()
        {
            this.associatedPlayersField = new List<PlayerPlayer>();
            this.matchStatisticsField = new PlayerMatchStatistics();
        }

        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public PlayerMatchStatistics MatchStatistics
        {
            get
            {
                return this.matchStatisticsField;
            }
            set
            {
                this.matchStatisticsField = value;
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Player", IsNullable = false)]
        public List<PlayerPlayer> AssociatedPlayers
        {
            get
            {
                return this.associatedPlayersField;
            }
            set
            {
                this.associatedPlayersField = value;
            }
        }

        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    public partial class PlayerMatchStatistics
    {

        private int assistsField;

        private int goalsField;

        private int totalAttendencesField;

        private int totalWaiversField;

        public PlayerMatchStatistics()
        {
            this.assistsField = 0;
            this.goalsField = 0;
            this.totalAttendencesField = 0;
            this.totalWaiversField = 0;
        }

        public int Assists
        {
            get
            {
                return this.assistsField;
            }
            set
            {
                this.assistsField = value;
            }
        }

        public int Goals
        {
            get
            {
                return this.goalsField;
            }
            set
            {
                this.goalsField = value;
            }
        }

        public int TotalAttendences
        {
            get
            {
                return this.totalAttendencesField;
            }
            set
            {
                this.totalAttendencesField = value;
            }
        }

        public int TotalWaivers
        {
            get
            {
                return this.totalWaiversField;
            }
            set
            {
                this.totalWaiversField = value;
            }
        }
    }

    public partial class PlayerPlayer
    {

        private string idField;

        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
}