using System.Runtime.Serialization;

namespace RestApp.Model.Base
{
    //contrato entre os atributos 
    // e a estrutura da tabela
    //[DataContract]
    public class BaseEntity
    {
        public long Id { get; set; }
    }
}
