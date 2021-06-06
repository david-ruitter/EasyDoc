using System;

namespace EasyDoc.Application.Requests.Documentation
{
    public class GetJavaDocumentation : DocumentationRequest
    {
        public GetJavaDocumentation(
            Guid aggregateId,
            string fileName,
            string fileContent) : base(aggregateId, fileName, fileContent)
        { 
        }
    }
}
