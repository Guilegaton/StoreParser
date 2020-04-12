using SimpleInjector;
using System.Windows;

namespace StoreParser.Business.Interfaces
{
    public interface IBaseDependendentWindow
    {
        void ProcessDependencies(Container container);
    }
}
