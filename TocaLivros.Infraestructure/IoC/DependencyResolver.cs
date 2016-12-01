using TocaLivros.Infraestructure.EntityFramework.Repository;
using TocaLivros.Infraestructure.EntityFramework.Context;
using TocaLivros.Domain.Contracts;
using Microsoft.Practices.Unity;

namespace TocaLivros.Infraestructure.IoC
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IPedidoRepository, PedidoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProdutoRepository, ProdutoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
        }
    }
}
