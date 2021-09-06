using Godot;

namespace BLL.Interface
{
    public interface IDashboardBLL
    {
        void InstanciarTab(TabContainer container, string caminhoTab, string nomeTab);
        void LimparMenuLateral(TabContainer container);
    }
}