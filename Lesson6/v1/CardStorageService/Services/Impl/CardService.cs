﻿using CardStorageServiceProtos;
using Grpc.Core;
using static CardStorageServiceProtos.CardService;

namespace CardStorageService.Services.Impl
{
    public class CardService :CardServiceBase
    {
        #region Services

        private readonly ICardRepositoryService _cardRepositoryService;

        #endregion


        public CardService(ICardRepositoryService cardRepositoryService)
        {
            _cardRepositoryService = cardRepositoryService;
        }

        public override Task<GetByClientIdResponse> GetByClientId(GetByClientIdRequest request, ServerCallContext context)
        {
            var response = new GetByClientIdResponse();

            response.Cards.AddRange((IEnumerable<CardStorageServiceProtos.Card>)_cardRepositoryService.GetByClientId(request.ClientId)
                .Select(card => new Card
                {
                    CardNo = card.CardNo,
                    CVV2 = card.CVV2,
                    ExpDate = card.ExpDate,
                    Name = card.Name
                }).ToList());

            return Task.FromResult(response);

        }
    }
}
