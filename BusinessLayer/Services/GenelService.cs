using System.Data;

namespace BusinessLayer.Services
{
    public class GenelService
    {
        ServiceBase<string> serviceBase = new ServiceBase<string>();

        int tip;
        public GenelService(int _tip)
        {
            tip = _tip;
        }

        public DataTable SelectText(string query, params object[] list)
        {
            return serviceBase.SelectText(tip, query, list);
        }

        public DataTable SelectProc(string query, params object[] list)
        {
            return serviceBase.SelectProc(tip, query, list);
        }
    }
}
