using HuiChengSite.Common;
using HuiChengSite.Models;
using HuiChengSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Service
{
    public class LabelService
    {
        private LabelRepository _labelRepository;

        public LabelService(LabelRepository LabelRepository)
        {
            _labelRepository = LabelRepository;
        }

        public int Add(string name)
        {
            if (_labelRepository.SelectByName(name) != null)
                throw new ValidateException(301, "标签已存在");

            var model = new Label();
            model.Name = name;
            return Add(model);
        }

        public int Add(Label model)
        {
            if (ContextUser.IsLogined)
                model.CreateUser = ContextUser.Email;

            var time = DateTime.Now;

            model.CreateTime = time;
            model.UpdateTime = time;
            model.Enable = 1;

            var id = _labelRepository.Add(model);
            return id;
        }

        public int Update(Label model)
        {
            var dbModel = _labelRepository.SelectByName(model.Name);
            if (dbModel != null && dbModel.LabelId != model.LabelId)
                throw new ValidateException(301, "标签已存在");

            model.UpdateTime = DateTime.Now;
            return _labelRepository.Update(model);
        }

        public List<Label> GetAll()
        {
            return _labelRepository.GetAll();
        }

        public List<Label> GetLablesByArticle(int articleId)
        {
            return _labelRepository.GetLablesByArticle(articleId);
        }
        
    }
}