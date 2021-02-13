using System;
using System.Threading.Tasks;
using Shop.Application.Files.Requests;
using Shop.Application.Files.Responses;
using Shop.Application.Products.Responses;
using Shop.Database.Repositories;
using Shop.Domain.Models;

namespace Shop.Application.Files
{
    public class CreateFile
    {
        private readonly FileRepository _fileRepository;

        public CreateFile(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<CreateFileResponse> Do(CreateFileRequest request)
        {
            File file = new File
            {
                MimeType = request.MimeType,
                Filename = request.Filename,
                UploadTime = request.UploadTime,
            };

            if (await _fileRepository.CreateFile(file) <= 0)
            {
                throw new Exception("Failed to create File");
            }

            return new CreateFileResponse
            {
                Id = file.Id,
                Filename = file.Filename,
                UploadTime = file.UploadTime,
                MimeType = file.MimeType,
            };
        }
    }
}