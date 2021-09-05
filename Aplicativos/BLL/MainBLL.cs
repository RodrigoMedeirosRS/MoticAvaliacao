using Godot;
using System;
using System.Text;
using System.Collections.Generic;

using BLL.Utils;
using BLL.Interface;

namespace BLL
{
    public class MainBLL : IMainBLL
    {
        public MainBLL()
        {

        }

        public void CarregarCena(Control container, string caminhoCena)
        {
          InstanciadorUtil.DecarregarFilhos(container);
          var cena = InstanciadorUtil.CarregarCena(caminhoCena);
          InstanciadorUtil.InstanciarObjeto(container, cena, new Vector2(0,0));
        }
    }
}