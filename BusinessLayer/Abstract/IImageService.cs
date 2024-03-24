﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageService
    {
        List<ImageFile> GetImageFileList();
        void ImageFileAdd(ImageFile ımageFile);
        ImageFile GetByID(int id);
        void ImageFileDelete(ImageFile ımageFile);
        void ImageFileUpdate(ImageFile ımageFile);
    }
}
