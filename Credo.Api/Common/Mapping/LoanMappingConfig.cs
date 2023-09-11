using Credo.Application.Loans.Commands.Create;
using Credo.Application.Loans.Common;
using Credo.Contracts.Loans.Requests;
using Credo.Contracts.Loans.Responses;
using Credo.Domain.Loans;
using Mapster;

namespace Credo.Api.Common.Mapping
{
    public class LoanMappingConfig
    {
        public void Loan(TypeAdapterConfig config)
        {
            config.NewConfig<CreateLoanRequest, CreateLoanCommand>();
            config.NewConfig<BaseResult, BaseCommandResponse>();
            config.NewConfig<Loan, LoanResponse>()
                .Map(dest => dest.Amount, src => src.Amount)
                .Map(dest => dest.Period, src => src.Period)
                .Map(dest => dest.LoanType, src => src.LoanType)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.UserId, src => src.UserId.Value);
        }
    }
}
