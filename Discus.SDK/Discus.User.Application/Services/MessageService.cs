using Discus.SDK.Repository.SqlSugar.Repository;
using Discus.Shared;
using Discus.User.Application.Contracts.Dtos;
using Discus.User.Repository.Entities;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discus.User.Application.Services
{
    public class MessageService : BasicService, IMessageService
    {
        private readonly ICapPublisher _capPublisher;
        private readonly IBaseRepository<UserInfo> _userinfoRepository;


        public MessageService(ICapPublisher capPublisher, IBaseRepository<UserInfo> userinfoRepository)
        {
            _capPublisher = capPublisher;
            _userinfoRepository = userinfoRepository;
        }

        public async Task Publish() 
        {
            var userInfo = await _userinfoRepository.GetByIdAsync(1);
            await _capPublisher.PublishAsync(EventNameConsts.DiscusUser, userInfo);
        }
    }
}
