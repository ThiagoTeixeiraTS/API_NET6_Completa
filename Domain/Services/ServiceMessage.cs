using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _IMessage;

        public ServiceMessage(IMessage IMessage)
        {
            _IMessage = IMessage;
        }

        public async Task Adicionar(Message obj)
        {
            var validTitle = obj.ValidaPropriedadeString(obj.Titulo, "Titulo");
            if(validTitle)
            {
                obj.DataCadastro = DateTime.Now;
                obj.DataAlteracao = DateTime.Now;
                obj.Ativo = true;
                await _IMessage.Add(obj);
            }
        }

        public async Task Atualizar(Message obj)
        {
            var validTitle = obj.ValidaPropriedadeString(obj.Titulo, "Titulo");
            if (validTitle)
            {
             
                obj.DataAlteracao = DateTime.Now;
                await _IMessage.Update(obj);
            }
        }

        public async Task<List<Message>> ListarMessageAtivas()
        {
            return await _IMessage.ListarMessage(n => n.Ativo);
        }
    }
}
