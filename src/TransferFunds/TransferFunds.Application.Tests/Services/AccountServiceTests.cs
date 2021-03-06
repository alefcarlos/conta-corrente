﻿using Framework.Test;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Threading.Tasks;
using TransferFunds.Application.ExternalServices;
using Xunit;

namespace TransferFunds.Application.Tests.Services
{
    /// <summary>
    /// Testes integrados da Account
    /// </summary>
    public class AccountServiceTests : BaseTest<Startup>
    {
        [Fact]
        public async Task GetAccountById_ShouldSuccess()
        {
            //Arrange
            var service = Scope.ServiceProvider.GetRequiredService<AccountService>();

            //Act
            var accountId = await service.CreateAccountAsync(new ViewModels.PostAccountRequest
            {
                CPF = "41469262894",
                Name = "Alef Carlos"
            });

            //Assert
            var result = await service.GetAccountByIDAsync(accountId);
            result.ShouldNotBeNull();
        }

        [Fact]
        public void GetAccountById_ShouldHaveError()
        {
            //Arrange
            var service = Scope.ServiceProvider.GetRequiredService<AccountService>();

            //Assert
            Func<Task> f = async () => { await service.GetAccountByIDAsync(new System.Guid()); };
            f.ShouldThrowAsync<Exception>();
        }
    }
}
