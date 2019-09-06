using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UploadFileResult
    {
        public class Arquivo
        {
            public int Tamanho { get; set; }
            public string Tipo { get; set; }
            public string Caminho { get; set; }
        }
    }
}