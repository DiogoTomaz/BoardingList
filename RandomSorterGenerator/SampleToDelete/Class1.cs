using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleToDelete
{
    public interface IBusinessLogicContext
    {
        IThemeMessageBusinessLogic ThemeAssetBL { get; }
        IThemeAssetBusinessLogic ThemeMessageBL { get; }
    }

    public interface IThemeMessageBusinessLogic
    {
        IAutomaticRejectionMsgBusinessLogic AutomaticRejectionMsgBL { get; set; }
    }

    public interface IThemeAssetBusinessLogic
    {
        IAssetVersionBusinessLogic AssetVersionBL { get; }
        IPersonBusinessLogic PersonBL { get; }
    }

    public interface IAssetVersionBusinessLogic
    {

    }

    public interface IPersonBusinessLogic
    {

    }

    public interface IAutomaticRejectionMsgBusinessLogic
    {
    }
}
