namespace ResultPipeline.Requests
{
    public class RequestCreateBeverage
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}";
        }
    }
}
