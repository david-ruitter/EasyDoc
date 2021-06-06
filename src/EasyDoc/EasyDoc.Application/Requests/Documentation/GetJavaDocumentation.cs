namespace EasyDoc.Application.Requests.Documentation
{
    public class GetJavaDocumentation : DocumentationRequest
    {
        public GetJavaDocumentation(
            string fileName,
            string fileContent) : base(fileName, fileContent)
        { 
        }
    }
}
