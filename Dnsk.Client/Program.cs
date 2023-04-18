using Common.Client;
using Dnsk.Client;
using Dnsk.I18n;

await Client.Run<App, Dnsk.Api.IApi>(args, S.Inst, Dnsk.Api.IApi.Init());
