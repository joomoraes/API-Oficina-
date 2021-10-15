namespace Api.Domain.Models
{
    public class UfModel: BaseModel
    {
        private string _sigla;
        public string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }

        private string _name;
        public string Nome
        {
            get { return _name; }
            set { _name = value; }
        }
        
        
    }
}
