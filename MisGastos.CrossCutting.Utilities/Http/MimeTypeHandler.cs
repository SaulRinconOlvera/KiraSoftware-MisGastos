using Microsoft.AspNetCore.StaticFiles;

namespace MisGastos.CrossCutting.Utilities.Http
{
    public class MimeTypeHandler
    {
        private static FileExtensionContentTypeProvider _provider;


        public static string GetMimeType(string fileName) 
        {
            string contentType;
            if (!GetProvider().TryGetContentType(fileName, out contentType)) 
                contentType = string.Empty;

            return contentType;
        }

        private static FileExtensionContentTypeProvider GetProvider()
        {
            if (_provider is null) _provider = new FileExtensionContentTypeProvider();
            return _provider;
        }
    }
}
