using CSRedis;
using Discus.SDK.Redis.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Discus.SDK.Redis
{
    public class RedisClient : IRedisClient
    {
        private readonly IOptions<RedisConfiguration> _options;

        private readonly ILogger<RedisClient> _logger;

        private readonly CSRedisClient _redisClient;

        public RedisClient(IOptions<RedisConfiguration> options, ILogger<RedisClient> logger, CSRedisClient redisClient)
        {
            _options = options;
            _logger = logger;
            _redisClient=redisClient;
            logger.LogInformation("redis初始化完成");
        }

        #region Keys
        public long KeyDel(string cacheKey)
        {
            return _redisClient.Del(cacheKey);
        }

        public async Task<long> KeyDelAsync(string cacheKey)
        {
            return await _redisClient.DelAsync(cacheKey);
        }

        public bool KeyExists(string cacheKey)
        {
            return _redisClient.Exists(cacheKey);
        }

        public async Task<bool> KeyExistsAsync(string cacheKey)
        {
            return await _redisClient.ExistsAsync(cacheKey);
        }

        public bool KeyExpire(string cacheKey, int second)
        {
            return _redisClient.Expire(cacheKey, second);
        }

        public async Task<bool> KeyExpireAsync(string cacheKey, int second)
        {
            return await _redisClient.ExpireAsync(cacheKey, second);
        }

        public long TTL(string cacheKey)
        {
            return _redisClient.Ttl(cacheKey);
        }

        public async Task<long> TTLAsync(string cacheKey)
        {
            return await _redisClient.TtlAsync(cacheKey);
        }
        #endregion

        #region String
        public long IncrBy(string cacheKey, long value = 1)
        {
            return _redisClient.IncrBy(cacheKey, value);
        }

        public async Task<long> IncrByAsync(string cacheKey, long value = 1)
        {
            return await _redisClient.IncrByAsync(cacheKey, value);
        }

        public decimal IncrByFloat(string cacheKey, decimal value = 1)
        {
            return _redisClient.IncrByFloat(cacheKey, value);
        }

        public async Task<decimal> IncrByFloatAsync(string cacheKey, decimal value = 1)
        {
            return await _redisClient.IncrByFloatAsync(cacheKey, value);
        }

        public bool StringSet(string cacheKey, object cacheValue, int expireSeconds = -1, RedisExistence? exists = null)
        {
            return _redisClient.Set(cacheKey, cacheValue, expireSeconds, exists);
        }

        public async Task<bool> StringSetAsync(string cacheKey, object cacheValue, int expireSeconds = -1, RedisExistence? exists = null)
        {
            return await _redisClient.SetAsync(cacheKey, cacheValue, expireSeconds, exists);
        }

        public string StringGet(string cacheKey)
        {
            return _redisClient.Get(cacheKey);

        }

        public async Task<string> StringGetAsync(string cacheKey)
        {
            return await _redisClient.GetAsync(cacheKey);
        }

        public long StringLen(string cacheKey)
        {
            return _redisClient.StrLen(cacheKey);
        }

        public async Task<long> StringLenAsync(string cacheKey)
        {
            return await _redisClient.StrLenAsync(cacheKey);
        }

        public long StringSetRange(string cacheKey, uint offest, string value)
        {
            return _redisClient.SetRange(cacheKey, offest, value);
        }

        public async Task<long> StringSetRangeAsync(string cacheKey, uint offest, string value)
        {
            return await _redisClient.SetRangeAsync(cacheKey, offest, value);
        }

        public string StringGetRange(string cacheKey, long start, long end)
        {
            return _redisClient.GetRange(cacheKey, start, end);
        }

        public async Task<string> StringGetRangeAsync(string cacheKey, long start, long end)
        {
            return await _redisClient.GetRangeAsync(cacheKey, start, end);
        }
        #endregion

        #region Hashes
        public bool HMSet(string cacheKey, Dictionary<string, string> vals, TimeSpan? expiration = null)
        {
            return _redisClient.HMSet(cacheKey, vals, expiration);
        }

        public bool HSet(string cacheKey, string field, string cacheValue)
        {
            return _redisClient.HSet(cacheKey, field, cacheValue);
        }

        public bool HExists(string cacheKey, string field)
        {
            return _redisClient.HExists(cacheKey, field);
        }

        public long HDel(string cacheKey, string[] fields = null)
        {
            return _redisClient.HDel(cacheKey, fields);

        }

        public string HGet(string cacheKey, string field)
        {
            return _redisClient.HGet(cacheKey, field);
        }

        public Dictionary<string, string> HGetAll(string cacheKey)
        {
            return _redisClient.HGetAll(cacheKey);
        }

        public long HIncrBy(string cacheKey, string field, long val = 1)
        {
            return _redisClient.HIncrBy(cacheKey, field, val);
        }

        public string[] HKeys(string cacheKey)
        {
            return _redisClient.HKeys(cacheKey);
        }

        public long HLen(string cacheKey)
        {
            return _redisClient.HLen(cacheKey);
        }

        public string[] HVals(string cacheKey)
        {
            return _redisClient.HVals(cacheKey);
        }

        public string[] HMGet(string cacheKey, string[] fields)
        {
            return _redisClient.HMGet(cacheKey, fields);
        }

        public async Task<bool> HMSetAsync(string cacheKey, object[] keyValues)
        {
            return await _redisClient.HMSetAsync(cacheKey, keyValues);
        }

        public async Task<bool> HSetAsync(string cacheKey, string field, string cacheValue)
        {
            return await _redisClient.HSetAsync(cacheKey, field, cacheValue);
        }

        public Task<bool> HExistsAsync(string cacheKey, string field)
        {
            return _redisClient.HExistsAsync(cacheKey, field);
        }

        public async Task<long> HDelAsync(string cacheKey, string[] fields)
        {
            return await _redisClient.HDelAsync(cacheKey, fields);
        }

        public async Task<string> HGetAsync(string cacheKey, string field)
        {
            return await _redisClient.HGetAsync(cacheKey, field);
        }

        public async Task<Dictionary<string, string>> HGetAllAsync(string cacheKey)
        {
            return await _redisClient.HGetAllAsync(cacheKey);
        }

        public async Task<long> HIncrByAsync(string cacheKey, string field, long val = 1)
        {
            return await _redisClient.HIncrByAsync(cacheKey, field, val);
        }

        public async Task<string[]> HKeysAsync(string cacheKey)
        {
            return await _redisClient.HKeysAsync(cacheKey);
        }

        public async Task<long> HLenAsync(string cacheKey)
        {
            return await _redisClient.HLenAsync(cacheKey);
        }

        public async Task<string[]> HValsAsync(string cacheKey)
        {
            return await _redisClient.HValsAsync(cacheKey);
        }

        public async Task<string[]> HMGetAsync(string cacheKey, string[] fields)
        {
            return await _redisClient.HMGetAsync(cacheKey, fields);
        }
        #endregion

        #region List
        public T LIndex<T>(string cacheKey, long index)
        {
            return _redisClient.LIndex<T>(cacheKey, index);
        }

        public long LLen(string cacheKey)
        {
            return _redisClient.LLen(cacheKey);
        }

        public T LPop<T>(string cacheKey)
        {
            return _redisClient.LPop<T>(cacheKey);
        }

        public long LPush<T>(string cacheKey, T[] cacheValues)
        {
            return _redisClient.LPush<T>(cacheKey, cacheValues);
        }

        public T[] LRange<T>(string cacheKey, long start, long stop)
        {
            return _redisClient.LRange<T>(cacheKey, start, stop);
        }

        public long LRem(string cacheKey, long count, object cacheValue)
        {
            return _redisClient.LRem(cacheKey, count, cacheValue);
        }

        public bool LSet(string cacheKey, long index, object cacheValue)
        {
            return _redisClient.LSet(cacheKey, index, cacheValue);
        }

        public bool LTrim(string cacheKey, long start, long stop)
        {
            return _redisClient.LTrim(cacheKey, start, stop);
        }

        public long LPushX(string cacheKey, object cacheValue)
        {
            return _redisClient.LPushX(cacheKey, cacheValue);
        }

        public long LInsertBefore(string cacheKey, object pivot, object cacheValue)
        {
            return _redisClient.LInsertBefore(cacheKey, pivot, cacheValue);
        }

        public long LInsertAfter(string cacheKey, object pivot, object cacheValue)
        {
            return _redisClient.LInsertAfter(cacheKey, pivot, cacheValue);
        }

        public long RPushX(string cacheKey, object cacheValue)
        {
            return _redisClient.RPushX(cacheKey, cacheValue);
        }

        public long RPush<T>(string cacheKey, T[] cacheValues)
        {
            return _redisClient.RPush<T>(cacheKey, cacheValues);
        }

        public T RPop<T>(string cacheKey)
        {
            return _redisClient.RPop<T>(cacheKey);
        }

        public async Task<T> LIndexAsync<T>(string cacheKey, long index)
        {
            return await _redisClient.LIndexAsync<T>(cacheKey, index);
        }

        public async Task<long> LLenAsync(string cacheKey)
        {
            return await _redisClient.LLenAsync(cacheKey);
        }

        public async Task<T> LPopAsync<T>(string cacheKey)
        {
            return await _redisClient.LPopAsync<T>(cacheKey);
        }

        public async Task<long> LPushAsync<T>(string cacheKey, T[] cacheValues)
        {
            return await _redisClient.LPushAsync<T>(cacheKey, cacheValues);
        }

        public async Task<T[]> LRangeAsync<T>(string cacheKey, long start, long stop)
        {
            return await _redisClient.LRangeAsync<T>(cacheKey, start, stop);
        }

        public async Task<long> LRemAsync(string cacheKey, long count, object cacheValue)
        {
            return await _redisClient.LRemAsync(cacheKey, count, cacheValue);
        }

        public async Task<bool> LSetAsync(string cacheKey, long index, object cacheValue)
        {
            return await _redisClient.LSetAsync(cacheKey, index, cacheValue);
        }

        public async Task<bool> LTrimAsync(string cacheKey, long start, long stop)
        {
            return await _redisClient.LTrimAsync(cacheKey, start, stop);
        }

        public async Task<long> LPushXAsync(string cacheKey, object cacheValue)
        {
            return await _redisClient.LPushXAsync(cacheKey, cacheValue);
        }

        public async Task<long> LInsertBeforeAsync(string cacheKey, object pivot, object cacheValue)
        {
            return await _redisClient.LInsertBeforeAsync(cacheKey, pivot, cacheValue);
        }

        public async Task<long> LInsertAfterAsync(string cacheKey, object pivot, object cacheValue)
        {
            return await _redisClient.LInsertAfterAsync(cacheKey, pivot, cacheValue);
        }

        public async Task<long> RPushXAsync(string cacheKey, object cacheValue)
        {
            return await _redisClient.RPushXAsync(cacheKey, cacheValue);
        }

        public async Task<long> RPushAsync<T>(string cacheKey, T[] cacheValues)
        {
            return await _redisClient.RPushAsync<T>(cacheKey, cacheValues);
        }

        public async Task<T> RPopAsync<T>(string cacheKey)
        {
            return await _redisClient.RPopAsync<T>(cacheKey);
        }
        #endregion

        #region Set

        public long SAdd<T>(string cacheKey, T[] cacheValues)
        {
            return _redisClient.SAdd<T>(cacheKey, cacheValues);
        }

        public long SCard(string cacheKey)
        {
            return _redisClient.SCard(cacheKey);
        }

        public bool SIsMember(string cacheKey, object cacheValue)
        {
            return _redisClient.SIsMember(cacheKey, cacheValue);
        }

        public string[] SMembers(string cacheKey)
        {
            return _redisClient.SMembers(cacheKey);
        }

        public T SPop<T>(string cacheKey)
        {
            return _redisClient.SPop<T>(cacheKey);
        }

        public T SRandMember<T>(string cacheKey)
        {
            return _redisClient.SRandMember<T>(cacheKey);
        }

        public long SRem<T>(string cacheKey, T[] cacheValues)
        {
            return _redisClient.SRem<T>(cacheKey, cacheValues);
        }

        public async Task<long> SAddAsync<T>(string cacheKey,T[] cacheValues)
        {
            return await _redisClient.SAddAsync<T>(cacheKey, cacheValues);
        }

        public async Task<long> SCardAsync(string cacheKey)
        {
            return await _redisClient.SCardAsync(cacheKey);
        }

        public async Task<bool> SIsMemberAsync(string cacheKey, object cacheValue)
        {
            return await _redisClient.SIsMemberAsync(cacheKey, cacheValue);
        }

        public async Task<string[]> SMembersAsync(string cacheKey)
        {
            return await _redisClient.SMembersAsync(cacheKey);
        }

        public async Task<T> SPopAsync<T>(string cacheKey)
        {
            return await _redisClient.SPopAsync<T>(cacheKey);
        }

        public async Task<T> SRandMemberAsync<T>(string cacheKey)
        {
            return await _redisClient.SRandMemberAsync<T>(cacheKey);
        }

        public async Task<long> SRemAsync<T>(string cacheKey, T[] cacheValues)
        {
            return await _redisClient.SRemAsync<T>(cacheKey, cacheValues);
        }
        #endregion

        #region Sorted Set
        public long ZAdd(string cacheKey, (decimal, object)[] cacheValues)
        {
            return _redisClient.ZAdd(cacheKey, cacheValues);  
        }

        public long ZCard(string cacheKey)
        {
            return _redisClient.ZCard(cacheKey);
        }

        public long ZCount(string cacheKey, decimal min, decimal max)
        {
            return _redisClient.ZCount(cacheKey, min, max);
        }

        public decimal ZIncrBy(string cacheKey, string field, decimal increment = 1m)
        {
            return _redisClient.ZIncrBy(cacheKey, field, increment);
        }

        public long ZLexCount(string cacheKey, string min, string max)
        {
            return _redisClient.ZLexCount(cacheKey, min, max);
        }

        public T[] ZRange<T>(string cacheKey, long start, long stop)
        {
            return _redisClient.ZRange<T>(cacheKey, start, stop);
        }

        public long? ZRank(string cacheKey, object cacheValue)
        {
            return _redisClient.ZRank(cacheKey, cacheValue);
        }

        public long ZRem<T>(string cacheKey, T[] cacheValues)
        {
            return _redisClient.ZRem(cacheKey, cacheValues);
        }

        public decimal? ZScore(string cacheKey, object cacheValue)
        {
            return _redisClient.ZScore(cacheKey, cacheValue);
        }

        public async Task<long> ZAddAsync(string cacheKey, params (decimal, object)[] cacheValues)
        {
            return await _redisClient.ZAddAsync(cacheKey, cacheValues);
        }

        public async Task<long> ZCardAsync(string cacheKey)
        {
            return await _redisClient.ZCardAsync(cacheKey);
        }

        public async Task<long> ZCountAsync(string cacheKey, decimal min, decimal max)
        {
            return await _redisClient.ZCountAsync(cacheKey, min, max);
        }

        public async Task<decimal> ZIncrByAsync(string cacheKey, string field, decimal val = 1m)
        {
            return await _redisClient.ZIncrByAsync(cacheKey, field, val);
        }

        public async Task<long> ZLexCountAsync(string cacheKey, string min, string max)
        {
            return await _redisClient.ZLexCountAsync(cacheKey, min, max);
        }

        public async Task<T[]> ZRangeAsync<T>(string cacheKey, long start, long stop)
        {
            return await _redisClient.ZRangeAsync<T>(cacheKey, start, stop);
        }

        public async Task<long?> ZRankAsync(string cacheKey, object cacheValue)
        {
            return await _redisClient.ZRankAsync(cacheKey, cacheValue);
        }

        public async Task<long> ZRemAsync<T>(string cacheKey, T[] cacheValues)
        {
            return await _redisClient.ZRemAsync<T>(cacheKey, cacheValues);
        }

        public async Task<decimal?> ZScoreAsync<T>(string cacheKey, object cacheValue)
        {
            return await _redisClient.ZScoreAsync(cacheKey, cacheValue);

        }
        #endregion

        public async Task<dynamic> EvalAsync(string script, string keys, object[] args)
        {
            return await _redisClient.EvalAsync(script, keys, args);
        }

    }
}
