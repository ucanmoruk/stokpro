using System.Data.SqlClient;

namespace mKYS
{
    class sqlbaglanti
    {
        public SqlConnection baglanti()
        {
          
            SqlConnection baglan = new SqlConnection(@"Data Source=mssql04.trwww.com,1433; Initial Catalog = massgrup_cosmo; persist Security Info = True; User ID = cosmoroot; Password = 3Y3s!52qw ; MultipleActiveResultSets=True; Connection Timeout=900");
            baglan.Open();
            return baglan;
            
        }
    }
}
