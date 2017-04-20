﻿import { autoinject } from 'aurelia-framework';

@autoinject export default class ClientStorage {

  constructor(readonly storage: Storage) { }

  store(key: StoreKey, value: {}) {
    this.storage[key] = value;
  }

  retreive(key: StoreKey): string {
    return this.storage[key];
  }

  clear(key?: StoreKey) {
    if (key) {
      delete this.storage[key];
    } else {
      this.storage.clear();
    }
  }
}

type StoreKey = 'auth_token';

export type Storage = typeof window.sessionStorage | typeof window.localStorage;