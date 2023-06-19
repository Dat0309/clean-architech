import React, { useEffect } from 'react';
import Footer from '../../components/Footer/Footer';
import { Header, SliderCustom, Contact, BoxContent } from '../../components';
import { HorizontalBox, SpecialVerticalBox, VerticalBox } from '../../components/BoxItem';
import { sliderType } from '../../components/SliderCustom/SliderType';
import { useDispatch, useSelector } from 'react-redux';
import { Grid } from 'semantic-ui-react';
import { convertDate } from '../../config/Function';

import srcUrl from "../../srcURL.json";
import "./Home.scss"
import { setActiveMenuModal } from '../../redux/features/GeneralSlice';
import { useTranslation } from 'react-i18next';
import { screenType } from '../../config/ScreenType';
import { menu } from '../../config/MenuName';

const Home = () => {

    const { news, blogs } = useSelector(state => state.post)
    const { currentWidth } = useSelector(state => state.general)

    const dispatch = useDispatch()

    const { t } = useTranslation()
    const translate = t

    // Highlight home text on MenuModal
    useEffect(() => {
        dispatch(setActiveMenuModal(menu.home))
    }, []) // eslint-disable-line react-hooks/exhaustive-deps

    return (
        <div className='homepage'>
            <Header />
            <SliderCustom type={sliderType.fullBox} />
            <BoxContent
                className="home-body__services"
                title={translate('boxcontent.services.title')}
                subtitle={translate('boxcontent.services.subtile')}>
                <SliderCustom
                    type={sliderType.horizontalBoxBasic}
                />
            </BoxContent>
            <BoxContent
                className="home-body__domains"
                title={translate('boxcontent.domains.title')}
                bgImage={srcUrl['bgImage-homebodydomains']}>
                <SliderCustom
                    type={sliderType.horizontalBox}
                />
            </BoxContent>
            <BoxContent
                className="home-body__innovations"
                title={translate('boxcontent.innovations.title')}>
                <HorizontalBox
                    image={srcUrl['image-homebodyinnovations']}
                    withLeftItem="7"
                    withRightItem="9"
                    bgColor="true"
                    fontSize="22"
                >
                    {translate('boxcontent.innovations.content')}
                </HorizontalBox>
            </BoxContent>
            <BoxContent
                className="home-body__models"
                title={translate('boxcontent.models.title')}
                subtitle={translate('boxcontent.models.subtile')}>
                <Grid columns={currentWidth <= screenType.tablet ? 1 : 3} className='center'>
                    <Grid.Row>
                        <Grid.Column>
                            <SpecialVerticalBox
                                icon={srcUrl['icon-homebodymodels1']}
                                link={srcUrl['link-homebodymodels1']}
                                title={translate('boxcontent.models.child1.title')} >
                                <p className='bold'>{translate('boxcontent.models.child1.contentline1')}</p>
                                <p>{translate('boxcontent.models.child1.contentline2')}</p>
                                <p className='bold'>{translate('boxcontent.models.child1.contentline3')}</p>
                                <p>{translate('boxcontent.models.child1.contentline4')}</p>
                                <p className='bold'>{translate('boxcontent.models.child1.contentline5')}</p>
                                <p>{translate('boxcontent.models.child1.contentline6')}</p>
                            </SpecialVerticalBox>
                        </Grid.Column>
                        <Grid.Column>
                            <SpecialVerticalBox
                                icon={srcUrl['icon-homebodymodels2']}
                                link={srcUrl['link-homebodymodels2']}
                                title={translate('boxcontent.models.child2.title')}>
                                <p className='bold'>{translate('boxcontent.models.child2.contentline1')}</p>
                                <p>{translate('boxcontent.models.child2.contentline2')}</p>
                                <p className='bold'>{translate('boxcontent.models.child2.contentline3')}</p>
                                <p>{translate('boxcontent.models.child2.contentline4')}</p>
                            </SpecialVerticalBox>
                        </Grid.Column>
                        <Grid.Column>
                            <SpecialVerticalBox
                                icon={srcUrl['icon-homebodymodels3']}
                                link={srcUrl['link-homebodymodels3']}
                                title={translate('boxcontent.models.child3.title')}>
                                <p className='bold'>{translate('boxcontent.models.child3.contentline1')}</p>
                                <p>{translate('boxcontent.models.child3.contentline2')}</p>
                                <p className='bold'>{translate('boxcontent.models.child3.contentline3')}</p>
                                <p>{translate('boxcontent.models.child3.contentline4')}</p>
                                <p className='bold'>{translate('boxcontent.models.child3.contentline5')}</p>
                                <p>{translate('boxcontent.models.child3.contentline6')}</p>
                            </SpecialVerticalBox>
                        </Grid.Column>
                    </Grid.Row>
                </Grid>
            </BoxContent>
            <BoxContent
                className="home-body__clients"
                title={translate('boxcontent.clients.title')}
                bgImage={srcUrl['bgImage-homebodyclients']}>
                <SliderCustom
                    type={sliderType.imageBox}
                />
            </BoxContent>
            <BoxContent
                className="home-body__testimonials"
                title={translate('boxcontent.testimonials.title')}
                subtitle={translate('boxcontent.testimonials.subtitle')}>
                <SliderCustom
                    type={sliderType.horizontalBoxPagination}
                />
            </BoxContent>
            <div className='home-body__recognize-container'>
                <div className="home-body__recognize-container--maxwidth">
                    <h2>{translate('boxcontent.recognize.title')}</h2>
                    <SliderCustom type={sliderType.imageBoxBasic} />
                </div>
            </div>
            <BoxContent
                className="home-body__job"
                title={translate('boxcontent.jobs.title')}>
                <HorizontalBox
                    image={srcUrl['image-homebody-job']}
                    withLeftItem="6"
                    withRightItem="10"
                    fontSize="27"
                    btn={translate('boxcontent.jobs.button')}
                >
                    {translate('boxcontent.jobs.content')}
                </HorizontalBox>
            </BoxContent>
            <BoxContent
                className="home-body__news"
                title={translate('boxcontent.news.title')}>
                <Grid columns={currentWidth <= screenType.tablet ? 1 : 3} className='center'>
                    <Grid.Row >
                        {
                            news.status.success && news.data.slice(0, 3).reverse().map((item, index) => (
                                <Grid.Column key={index}>
                                    <VerticalBox
                                        image={item.image}
                                        header={item.title}
                                        description={item.shortDescription}
                                        link={item.url}>
                                    </VerticalBox>
                                </Grid.Column>
                            ))
                        }
                    </Grid.Row>
                </Grid>
            </BoxContent>
            <BoxContent
                className="home-body__blogs"
                title={translate('boxcontent.blogs.title')}>
                <Grid columns={currentWidth <= screenType.tablet ? 1 : 3} className='center'>
                    <Grid.Row>
                        {
                            blogs.status.success && blogs.data.slice(-3).reverse().map((item, index) => (
                                <Grid.Column key={index}>
                                    <VerticalBox
                                        image={item.image}
                                        author={item.author}
                                        header={item.title}
                                        description={item.shortDescription}
                                        link={item.url}
                                        postdate={convertDate(item.createdTime)}>
                                    </VerticalBox>
                                </Grid.Column>
                            ))
                        }
                    </Grid.Row>
                </Grid>
            </BoxContent>
            <BoxContent
                className="home-body__request"
                title={translate('boxcontent.contact.title')}
                subtitle={translate('boxcontent.contact.subtitle')}>
                <Contact />
            </BoxContent>
            <Footer />
        </div>
    )
}

export default Home
