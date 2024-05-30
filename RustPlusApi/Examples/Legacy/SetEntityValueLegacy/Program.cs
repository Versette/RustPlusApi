﻿using Newtonsoft.Json;

using RustPlusApi;

using static __Constants.ExamplesConst;

var rustPlus = new RustPlusLegacy(Ip, Port, PlayerId, PlayerToken);
const uint entityId = 0;
const bool value = true;

rustPlus.Connected += async (_, _) =>
{
    var message = await rustPlus.SetEntityValueLegacyAsync(entityId, value);

    Console.WriteLine($"Infos:\n{JsonConvert.SerializeObject(message, JsonSettings)}");

    rustPlus.Dispose();
};

await rustPlus.ConnectAsync();