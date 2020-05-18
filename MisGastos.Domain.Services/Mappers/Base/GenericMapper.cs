using AutoMapper;
using System.Collections.Generic;

namespace MisGastos.Domain.Services.Mappers.Base
{
    public class GenericMapper<T, TViewModel> : IGenericMapper<T, TViewModel>
    where T : class where TViewModel : class
    {
        private readonly IMapper _mapper;

        public GenericMapper(IMapper mapper) => _mapper = mapper;

        public IEnumerable<T> GetEntities(IEnumerable<TViewModel> viewModels) =>
            _mapper.Map<IEnumerable<T>>(viewModels);

        public T GetEntity(TViewModel viewModel) => _mapper.Map<T>(viewModel);
        public TViewModel GetViewModel(T entity) => _mapper.Map<TViewModel>(entity);

        public IEnumerable<TViewModel> GetViewModels(IEnumerable<T> entities) =>
            _mapper.Map<IEnumerable<TViewModel>>(entities);
    }
}
