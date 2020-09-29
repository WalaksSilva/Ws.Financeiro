using System;
using System.Collections.Generic;
using System.Text;
using Ws.Financeiro.Domain.Notificacoes;

namespace Ws.Financeiro.Domain.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
