import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'UnitTesting',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44350/',
    redirectUri: baseUrl,
    clientId: 'UnitTesting_App',
    responseType: 'code',
    scope: 'offline_access UnitTesting',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44350',
      rootNamespace: 'UnitTesting',
    },
  },
} as Environment;
