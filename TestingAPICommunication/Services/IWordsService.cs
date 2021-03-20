using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestingAPICommunication.Models;

namespace TestingAPICommunication.Services
{
    interface IWordsService
    {
       Task<Definition> GetDefinitionAsync(string word);
    }
}
