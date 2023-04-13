namespace Home.Api.Contracts
{
    /// <summary>
    /// Информация о вашем доме (модель ответа)
    /// </summary>
    public class InfoResponse
    {
        public int FloorAmount { get; set; }
        public string Telephone { get; set; } = null!;
        public string Heating { get; set; } = null!;
        public int CurrentVolts { get; set; }
        public bool GasConnected { get; set; }
        public int Area { get; set; }
        public string Material { get; set; } = null!;
        public AddressInfo AddressInfo { get; set; } = null!;
    }

    public class AddressInfo
    {
        public int House { get; set; }
        public int Building { get; set; }
        public string Street { get; set; } = null!;
    }
}
