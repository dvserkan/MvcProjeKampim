using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _ImageDal;

        public ImageManager(IImageDal ımageDal)
        {
            _ImageDal = ımageDal;
        }

        public ImageFile GetByID(int id)
        {
            return _ImageDal.Get(x => x.ImageID == id);
        }

        public List<ImageFile> GetImageFileList()
        {
            return _ImageDal.List();
        }

        public void ImageFileAdd(ImageFile ımageFile)
        {
            _ImageDal.Insert(ımageFile);
        }

        public void ImageFileDelete(ImageFile ımageFile)
        {
            _ImageDal.Delete(ımageFile);
        }

        public void ImageFileUpdate(ImageFile ımageFile)
        {
            _ImageDal.Update(ımageFile);
        }
    }
}
