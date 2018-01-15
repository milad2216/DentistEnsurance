using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Web.ViewModel;
using Kendo.Mvc.UI;
using Entity;
using Entity.Common;

namespace Web.Infra
{
    public static class ViewModelUtils
    {
        public static TViewModel ToViewModel<TViewModel>(this object model) where TViewModel : IBaseViewModel
        {
            return (TViewModel)Mapper.Map(model, model.GetType(), typeof(TViewModel));
        }


        public static List<TViewModel> ToViewModel<TViewModel>(this IEnumerable model) where TViewModel : class
        {
            var result = new List<TViewModel>();
            foreach (var row in model)
            {
                result.Add((TViewModel)Mapper.Map(row, row.GetType(), typeof(TViewModel)));
            }
            return result;
        }
        public static MyDataSourceResult ToViewModel<TViewModel>(this MyDataSourceResult dataSourceResult, QueryInfo request) where TViewModel : IBaseViewModel
        {
            var result = new List<TViewModel>();
            int offset = (request.Page - 1) * request.PageSize; // dataSourceResult.;
            int cnt = 1;
            foreach (var row in dataSourceResult.data)
            {
                var viewModel = (TViewModel)Mapper.Map(row, row.GetType(), typeof(TViewModel));
                viewModel.Radif = offset + cnt++;
                result.Add(viewModel);
            }
            dataSourceResult.data = result;
            return dataSourceResult;
        }

        public static MyDataSourceResult ToViewModelDynamicMap<TViewModel>(this MyDataSourceResult dataSourceResult, QueryInfo request) where TViewModel : IBaseViewModel
        {
            var result = new List<TViewModel>();
            int offset = (request.Page - 1) * request.PageSize; // dataSourceResult.;
            int cnt = 1;
            foreach (var row in dataSourceResult.data)
            {
                var viewModel = (TViewModel)Mapper.DynamicMap(row, row.GetType(), typeof(TViewModel));
                viewModel.Radif = offset + cnt++;
                result.Add(viewModel);
            }
            dataSourceResult.data = result;
            return dataSourceResult;
        }

    }
}