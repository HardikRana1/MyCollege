import { ProHardikV1TemplatePage } from './app.po';

describe('ProHardikV1 App', function() {
  let page: ProHardikV1TemplatePage;

  beforeEach(() => {
    page = new ProHardikV1TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
