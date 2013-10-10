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


    public partial class Match
    {

        private MatchHomeTeam homeTeamField;

        private MatchAwayTeam awayTeamField;

        private MatchResult resultField;

        private string venueLocationField;

        private System.DateTime eventTimeField;

        private decimal totalPriceField;

        private decimal pricePerPersonField;

        private bool wasCanceledField;

        private string reportField;

        private string logisticsInformationField;

        private sbyte playersPerTeamField;

        private MatchType typeField;

        private MatchPitchType pitchTypeField;

        private MatchPitchLocation pitchLocationField;

        public Match()
        {
            this.resultField = new MatchResult();
            this.awayTeamField = new MatchAwayTeam();
            this.homeTeamField = new MatchHomeTeam();
        }

        public MatchHomeTeam HomeTeam
        {
            get
            {
                return this.homeTeamField;
            }
            set
            {
                this.homeTeamField = value;
            }
        }

        public MatchAwayTeam AwayTeam
        {
            get
            {
                return this.awayTeamField;
            }
            set
            {
                this.awayTeamField = value;
            }
        }

        public MatchResult Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        public string VenueLocation
        {
            get
            {
                return this.venueLocationField;
            }
            set
            {
                this.venueLocationField = value;
            }
        }

        public System.DateTime EventTime
        {
            get
            {
                return this.eventTimeField;
            }
            set
            {
                this.eventTimeField = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return this.totalPriceField;
            }
            set
            {
                this.totalPriceField = value;
            }
        }

        public decimal PricePerPerson
        {
            get
            {
                return this.pricePerPersonField;
            }
            set
            {
                this.pricePerPersonField = value;
            }
        }

        public bool WasCanceled
        {
            get
            {
                return this.wasCanceledField;
            }
            set
            {
                this.wasCanceledField = value;
            }
        }

        public string Report
        {
            get
            {
                return this.reportField;
            }
            set
            {
                this.reportField = value;
            }
        }

        public string LogisticsInformation
        {
            get
            {
                return this.logisticsInformationField;
            }
            set
            {
                this.logisticsInformationField = value;
            }
        }

        public sbyte PlayersPerTeam
        {
            get
            {
                return this.playersPerTeamField;
            }
            set
            {
                this.playersPerTeamField = value;
            }
        }

        public MatchType Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        public MatchPitchType PitchType
        {
            get
            {
                return this.pitchTypeField;
            }
            set
            {
                this.pitchTypeField = value;
            }
        }

        public MatchPitchLocation PitchLocation
        {
            get
            {
                return this.pitchLocationField;
            }
            set
            {
                this.pitchLocationField = value;
            }
        }
    }

    public partial class MatchHomeTeam
    {

        private MatchHomeTeamTeam teamField;

        public MatchHomeTeam()
        {
            this.teamField = new MatchHomeTeamTeam();
        }

        public MatchHomeTeamTeam Team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }
    }

    public partial class MatchHomeTeamTeam
    {

        private string nameField;

        private List<MatchHomeTeamTeamPlayer> playersField;

        private string idField;

        public MatchHomeTeamTeam()
        {
            this.playersField = new List<MatchHomeTeamTeamPlayer>();
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

        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Player", IsNullable = false)]
        public List<MatchHomeTeamTeamPlayer> Players
        {
            get
            {
                return this.playersField;
            }
            set
            {
                this.playersField = value;
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

    public partial class MatchHomeTeamTeamPlayer
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

    public partial class MatchAwayTeam
    {

        private MatchAwayTeamTeam teamField;

        public MatchAwayTeam()
        {
            this.teamField = new MatchAwayTeamTeam();
        }

        public MatchAwayTeamTeam Team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }
    }

    public partial class MatchAwayTeamTeam
    {

        private string nameField;

        private List<MatchAwayTeamTeamPlayer> playersField;

        private string idField;

        public MatchAwayTeamTeam()
        {
            this.playersField = new List<MatchAwayTeamTeamPlayer>();
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

        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Player", IsNullable = false)]
        public List<MatchAwayTeamTeamPlayer> Players
        {
            get
            {
                return this.playersField;
            }
            set
            {
                this.playersField = value;
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

    public partial class MatchAwayTeamTeamPlayer
    {

        private string idField;

        private string valueField;

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

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    public partial class MatchResult
    {

        private int homeResultField;

        private int awayResultField;

        public int HomeResult
        {
            get
            {
                return this.homeResultField;
            }
            set
            {
                this.homeResultField = value;
            }
        }

        public int AwayResult
        {
            get
            {
                return this.awayResultField;
            }
            set
            {
                this.awayResultField = value;
            }
        }
    }

    public enum MatchType
    {

        /// <remarks/>
        FutSal,

        /// <remarks/>
        Football,

        /// <remarks/>
        Basketball,
    }

    public enum MatchPitchType
    {

        /// <remarks/>
        Vynil,

        /// <remarks/>
        SintheticGrass,

        /// <remarks/>
        GrassMat,

        /// <remarks/>
        Wood,

        /// <remarks/>
        Grass,
    }

    public enum MatchPitchLocation
    {

        /// <remarks/>
        Indoor,

        /// <remarks/>
        Outdoor,
    }
}
