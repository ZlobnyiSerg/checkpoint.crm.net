using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Dictionaries
{
    /// <summary>
    ///     Тип документа, удостоверяющего личность
    /// </summary>
    public class DocumentType : DictionaryEntityBaseModel
    {
        public DocumentType()
        {
        }

        public DocumentType(string code, string name) : base(code, name)
        {
        }
    }
}