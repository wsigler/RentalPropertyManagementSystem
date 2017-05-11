using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMS_Database
{
    public class DictionaryDAL
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        public void AddDictionaries(List<Dictionary> dictionaries)
        {
            try
            {
                dictionaries.ForEach(x => {
                    AddDictionary(x);
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddDictionary(Dictionary dictionary)
        {
            try
            {
                db.Dictionaries.InsertOnSubmit(dictionary);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDictionary(Dictionary dictionary)
        {
            var editedDictionary = db.Dictionaries.FirstOrDefault(x => x.ID == dictionary.ID);
            editedDictionary.ID = dictionary.ID;
            editedDictionary.Category = dictionary.Category;
            editedDictionary.EntryName = dictionary.EntryName;
            editedDictionary.Description = dictionary.Description;

            db.SubmitChanges();
        }
    }
}
