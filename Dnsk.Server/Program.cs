using Common.Server;
using Dnsk.Service.Services;
using Dnsk.Db;
using Dnsk.I18n;

Server.Run<DnskDb, ApiService>(args, S.UnexpectedError);
