using HuiChengSite.Models;
using HuiChengSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Service
{
    public class CommentService
    {
        private CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public int Add(Comment model)
        {
            var time = DateTime.Now;

            model.CreateTime = time;
            model.UpdateTime = time;
            model.Enable = 1;

            var id = _commentRepository.Add(model);
            return id;
        }

        //public int Update(Comment model)
        //{
        //    model.UpdateTime = DateTime.Now;
        //    return _CommentRepository.Update(model);
        //}

        public void Remove(int id)
        {
            _commentRepository.Remove(id);
        }

        public Comment GetById(string CommentId)
        {
            return _commentRepository.GetById(CommentId);
        }

        public CommentListModelResult GetPaged(CommentListQuery listModel)
        {
            return _commentRepository.GetPaged(listModel);
        }

        public CommentInfoListModelResult GetInfoPaged(CommentInfoListQuery listModel)
        {
            return _commentRepository.GetInfoPaged(listModel);
        }

        public List<Comment> GetByParentIds(List<int> ids)
        {
            return _commentRepository.GetByParentIds(ids);
        }
    }
}