﻿using Newtonsoft.Json;

using RustPlusApi;

using static __Constants.ExamplesConst;

var rustPlus = new RustPlusLegacy(Ip, Port, PlayerId, PlayerToken);
const uint entityId = 3716008;

rustPlus.Connected += async (_, _) =>
{
    var message = await rustPlus.GetEntityInfoLegacyAsync(entityId);

    Console.WriteLine($"Infos:\n{JsonConvert.SerializeObject(message, JsonSettings)}");
};

rustPlus.MessageReceived += (_, message) =>
{
    if (message.Broadcast is not { EntityChanged: not null }) return;

    Console.WriteLine($"Message:\n{JsonConvert.SerializeObject(message, JsonSettings)}");
};

await rustPlus.ConnectAsync();