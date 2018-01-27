import 'flat-map';
import { bindable } from 'aurelia-framework';
import deepFreeze from 'deep-freeze';
import DocumentModel from 'models/document-model';
import { LexicalModel } from 'models/lexical-model-core';

export class DocumentViewer {

  @bindable document: DocumentModel;
  @bindable typeAheadSource: LexicalModel[] = [];
  @bindable searchTerm = '';

  bind() {
    this.typeAheadSource = this.document && this.document.paragraphs
      .flatMap(p => p.sentences)
      .flatMap(s => s.phrases)
      .flatMap(s => s.words);
  }

  queryTypeAhead(query: { target: { value: {} } }, callback: (...args: {}[]) => void) {
    console.log(query);
    console.log(callback);
    return callback(query.target.value);
  }

  search = (query: {}) => {
    return this.typeAheadSource.filter(x => x.text === query);
  }

  readonly typeaheadOptions = deepFreeze({
    hint: true,
    async: true,
    highlight: true,
    minLength: 2,
    display: 'text',
    datasets: {
      name: 'my-dataset',
      source: this.typeAheadSource
    }
  });
}