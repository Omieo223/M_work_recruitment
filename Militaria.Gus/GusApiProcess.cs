namespace Militaria.Gus
{
    public static class GusApiProcess
    {
        const string areaEndPoint = "https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area";

        public static async Task<AreaClass[]> GetEndPoint()
        {
            try
            {
                HttpClient client = new HttpClient();

                var result = await client.GetAsync(areaEndPoint,new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var respoJSON = await result.Content.ReadAsStringAsync();

                    var respoArr = System.Text.Json.JsonSerializer.Deserialize<AreaClass[]>(respoJSON);
                    return respoArr;
                }
            }
            catch (Exception ex) 
            {

            }

            AreaClass[] name = new AreaClass[0];
            return name;


        }
    }
}